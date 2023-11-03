Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports VB6 = Microsoft.VisualBasic
Imports System.IO
Imports System.Drawing.Drawing2D
Imports C1.Win.C1FlexGrid
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Globalization
Imports System.TimeSpan
Imports System.Text
Imports System.Runtime
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Linq

Module mdlFunction
    Public Const HWND_TOPMOST = -1
    Private Const SWP_NOMOVE = &H2
    Private Const SWP_NOSIZE = &H1

    Public Function IsLoadForm(ByVal formname As String) As Boolean
        For i As Integer = 0 To Application.OpenForms.Count - 1
            If TypeName(Application.OpenForms(i)).ToUpper = formname.ToUpper Then _
                Return True
        Next
        Return False
    End Function
    Public Function GetSrvDate() As Date ' Lay ngay gio may chu
        If Cn Is Nothing Then
            GetSrvDate = Now.Date
            Exit Function
        End If
        Dim SQLcmd As SqlClient.SqlCommand
        SQLcmd = New SqlClient.SqlCommand("SELECT GETDATE()")
        SQLcmd.Connection = Cn
        Dim dr As SqlClient.SqlDataReader = SQLcmd.ExecuteReader()
        Dim srvDate As Date
        dr.Read()
        srvDate = CType(dr(0), Date)
        dr.Close()
        GetSrvDate = srvDate
        SQLcmd.Dispose()
    End Function

    'Public Sub fg_2_Excell(ByVal fg As C1.Win.C1FlexGrid)
    '    Dim i As Integer, j As Integer
    '    Dim exc As Object
    '    '    On Error GoTo ErrHandler
    '    If fg.Rows = 2 Then Exit Sub
    '    exc = CreateObject("Excel.Application")
    '    exc.Workbooks.Add() '(App.Path + "\TGQS.xls")
    '    exc.Visible = True

    '    With exc
    '        For i = 0 To fg.Cols - 1
    '            .Cells(1, i + 1) = fg.TextMatrix(0, i)
    '            .Cells(2, i + 1) = fg.TextMatrix(1, i)
    '            .Cells(3, i + 1) = fg.TextMatrix(2, i)
    '            .Cells(4, i + 1) = fg.TextMatrix(3, i)
    '        Next
    '        'FrmProgrres.Show()
    '        'FrmProgrres.PrgBar.Max = fg.Rows + 1
    '        'FrmProgrres.PrgBar.Value = 1
    '        'FrmProgrres.Label1.Caption = "§ang thùc hiÖn..."
    '        'OnTop(FrmProgrres)
    '        For i = 4 To fg.Rows - 1
    '            For j = 0 To fg.Cols - 1
    '                If Len(fg.TextMatrix(i, j)) = 10 Then
    '                    '.Cells(i + 1, j + 1) = Left(fg.TextMatrix(i, j), 1) & vbLf & Right(fg.TextMatrix(i, j), 4)
    '                Else
    '                    .Cells(i + 1, j + 1) = Replace(Replace(fg.TextMatrix(i, j), Chr(10), vbCrLf), vbCr, "")
    '                End If
    '            Next
    '            'FrmProgrres.PrgBar.Value = FrmProgrres.PrgBar.Value + 1
    '        Next
    '        '        .Range("A1:" & Chr(65 + j) & 3).Font.Bold = True
    '        '        .Range("A1:" & Chr(65 + j) & 3).Font.Color = vbRed
    '        '        .Columns("$A:" & "$" & Chr(65 + j)).AutoFit
    '        '        .Columns("$A:" & "$" & Chr(65 + j)).Font.Name = ".vnTime"
    '        '        .Range("A1:" & "BB" & 3).Font.Bold = True
    '        '        .Range("A1:" & "BB" & 3).Font.Color = vbRed
    '        '        .Columns("$A:" & "$BB").AutoFit
    '        '        .Columns("$A:" & "$BB").Font.Name = ".vnTime"
    '        '
    '        'Unload(FrmProgrres)
    '    End With
    '    exc = Nothing
    '    Exit Sub
    '    'ErrHandler:
    '    '    MsgBox "Lçi: " & Err.Description
    'End Sub
    Public Function Thangtruoc_str(ByVal thang As Date) As String
        If Month(thang) = 1 Then
            Thangtruoc_str = (Year(thang) - 1).ToString + "/12"
        Else
            Thangtruoc_str = (Year(thang)).ToString.Trim + "/" + Format(Month(thang) - 1, "00")
        End If
    End Function

    Public Function Thangtruoc_txt(ByVal thang As Date) As String
        If Month(thang) = 1 Then
            Thangtruoc_txt = (Year(thang) - 1).ToString + "/12"
        Else
            Thangtruoc_txt = (Year(thang)).ToString.Trim + "/" + Format(Month(thang) - 1, "00")
        End If
    End Function
    Sub Thangtruoc(ByVal Nam As String, ByVal Thang As String, ByRef Nam1 As String, ByRef Thang1 As String)
        If Val(Thang) = 1 Then
            Nam1 = Trim(Str(Val(Nam) - 1))
            Thang1 = "12"
        Else
            Nam1 = Nam
            Thang1 = Trim(Str(Val(Thang) - 1))
        End If
    End Sub
    Sub Kytruoc(ByVal Nam As String, ByVal Thang As String, ByRef Nam1 As String, ByRef Thang1 As String)
        If Val(Thang) = 1 Then
            Nam1 = Trim(Str(Val(Nam) - 1))
            Thang1 = "4"
        Else
            Nam1 = Nam
            Thang1 = Trim(Str(Val(Thang) - 1))
        End If
    End Sub
    Sub Dottruoc(ByVal Nam As String, ByVal Thang As String, ByRef Nam1 As String, ByRef Thang1 As String)
        If Val(Thang) = 1 Then
            Nam1 = Trim(Str(Val(Nam) - 1))
            Thang1 = "2"
        Else
            Nam1 = Nam
            Thang1 = Trim(Str(Val(Thang) - 1))
        End If
    End Sub
    Sub Sau_Thangtruoc(ByVal Nam As String, ByVal Thang As String, ByRef Nam1 As String, ByRef Thang1 As String)
        If Thang = "6D" Then
            Nam1 = Trim(Str(Val(Nam) - 1))
            Thang1 = "6C"
        End If
        If Thang = "6C" Then
            Nam1 = Nam
            Thang1 = "6D"
        End If
        If Thang = "CN" Then
            Nam1 = Trim(Str(Val(Nam) - 1))
            Thang1 = "CN"
        End If
    End Sub
    Public Function getMd5Hash(ByVal input As String) As String
        Dim i
        Dim md5Hasher As MD5 = MD5.Create()
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))
        Dim sBuilder As StringBuilder = New StringBuilder()
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next
        Return sBuilder.ToString()
    End Function
    ' Lấy địa chỉ MAC
    Public Function Get_MAC_Address() As String
        Dim nics() As NetworkInterface
        Get_MAC_Address = ""
        'nhận tất cả các card mạng trên máy
        nics = NetworkInterface.GetAllNetworkInterfaces
        'cho listbox hiển thị tên các card mạng
        For Each nic As NetworkInterface In nics
            Dim nicSelected As NetworkInterface = nic
            If nicSelected.NetworkInterfaceType.ToString = "Ethernet" Then
                Dim pAddress As PhysicalAddress = nicSelected.GetPhysicalAddress()
                Dim bytes() As Byte = pAddress.GetAddressBytes
                'hiển thị các byte trên txtInformation
                For i As Integer = 0 To bytes.Length - 1
                    Get_MAC_Address &= bytes(i).ToString("X2")
                    If i <> bytes.Length - 1 Then
                        Get_MAC_Address &= "-"
                    End If
                Next
            End If
        Next
    End Function
    Public Function Get_MaxThutu(ByVal MaPK As String, ByVal Ngay As Date) As String
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Get_MaxThutu = "1"
        SQl = "select  isnull(Max(ThutuKham),0) as MaxTT from tblKhambenh_KQDVKHAM where  left(MaphieuCD,8) = 'PK'+'" & Format(Ngay, "yyMMdd") & "'  and Khoathuchien = '" & MaPK & "' "
        Cmd = New SqlCommand(SQl, Cn)
        rd = Cmd.ExecuteReader
        Do While rd.Read
            Get_MaxThutu = Trim(Str(rd!maxTT + 1))
        Loop
        rd.Close()
    End Function
    Public Function ReadMoney(ByVal Money As String) As String
        Dim temp = ""
        ReadMoney = ""
        Try
            '         Cho đủ 12 số
            Do While Len(Money) < 12
                Money = "0" + Money
            Loop
            Dim g1 As String = Money.Substring(0, 3)
            Dim g2 As String = Money.Substring(3, 3)
            Dim g3 As String = Money.Substring(6, 3)
            Dim g4 As String = Money.Substring(9, 3)

            '        //Đọc nhóm 1 ---------------------
            If (g1 <> "000") Then
                temp = ReadGroup3(g1)
                temp = temp + " Tỷ"
            End If
            '        //Đọc nhóm 2-----------------------
            If g2 <> "000" Then
                temp = temp + ReadGroup3(g2)
                temp = temp + " Triệu"
            End If
            '        //---------------------------------
            If g3 <> "000" Then
                temp = temp + ReadGroup3(g3)
                temp = temp + " Ngàn"
            End If
            '-----------------------------------
            'Chỗ này ko biết có nên ko ?
            'temp =temp + ReadGroup3(g4).Replace("Không Trăm Lẻ","Lẻ"); // Đọc 1000001 là Một Triệu Lẻ Một thay vì Một Triệu Không Trăm Lẻ 1;
            temp = temp + ReadGroup3(g4)
            '---------------------------------
            'Tinh chỉnh
            temp = temp.Replace("Một Mươi", "Mười")
            temp = temp.Trim()
            If (temp.IndexOf("Không Trăm") = 0) Then temp = temp.Remove(0, 10)
            temp = temp.Trim()
            If (temp.IndexOf("Lẻ") = 0) Then temp = temp.Remove(0, 2)
            temp = temp.Trim()
            temp = temp.Replace("Mươi Một", "Mươi Mốt")
            temp = temp.Trim()
            'Change Case
            ReadMoney = temp.Substring(0, 1).ToUpper() + temp.Substring(1).ToLower()
        Catch ex As Exception
        End Try
    End Function
    Private Function ReadGroup3(ByVal G3 As String) As String
        Dim ReadDigit() As String = {" Không", " Một", " Hai", " Ba", " Bốn", " Năm", " Sáu", " Bảy", " Tám", " Chín"}
        Dim temp As String = ""
        If G3 = "000" Then
            ReadGroup3 = ""
            Exit Function
        End If

        'Đọc số hàng trăm
        temp = ReadDigit(Int(Val(G3(0)))) + " Trăm"
        'Đọc số hàng chục
        If G3(1) = "0" Then
            If G3(2) = "0" Then
                ReadGroup3 = temp
                Exit Function
            Else
                temp = temp + " Lẻ" + ReadDigit(Int(Val(G3(2))))
                ReadGroup3 = temp
                Exit Function
            End If
        Else
            temp = temp + ReadDigit(Int(Val(G3(1)))) + " Mươi"
        End If
        'Đọc hàng đơn vị
        If G3(2) = "5" Then
            temp = temp + " Lăm"
        Else
            If G3(2) <> "0" Then temp = temp + ReadDigit(Int(Val(G3(2))))
        End If
        ReadGroup3 = temp
    End Function
    Public Sub AutoFill_Makhambenh(ByRef txt As TextBox)
        If txt.Text.Trim() = "" Then Exit Sub
        Select Case Len(Trim(txt.Text))
            Case 1
                txt.Text = Format(GetSrvDate(), "yyMMdd") + "000" + txt.Text
            Case 2
                txt.Text = Format(GetSrvDate(), "yyMMdd") + "00" + txt.Text
            Case 3
                txt.Text = Format(GetSrvDate(), "yyMMdd") + "0" + txt.Text
            Case 4
                txt.Text = Format(GetSrvDate(), "yyMMdd") + txt.Text
        End Select
    End Sub

    Public Function PhantramDCT(ByVal MaDTThe As String, ByVal Mathe As String, ByVal Tuyen As String) As Double
        'Hàm lấy phần trăm đồng chi trả theo mức quyền lợi, loại thẻ mới hay cũ, đúng tuyến , cấp cứu hay trái tuyến
        Try
            PhantramDCT = 0
            If Len(Mathe) = 13 Then
                If Tuyen = "Đúng tuyến" Then
                    Select Case Mid(Mathe, 1, 1)
                        Case 1 : PhantramDCT = 0
                        Case 2 : PhantramDCT = 0
                        Case 3 : PhantramDCT = 0
                        Case 4 : PhantramDCT = 5
                        Case 5 : PhantramDCT = 5
                        Case 6 : PhantramDCT = 20
                        Case 7 : PhantramDCT = 20
                        Case 9 : PhantramDCT = 0
                    End Select
                End If
                If Tuyen = "Trái tuyến" Then
                    PhantramDCT = PhanTram_TraiTuyen
                End If
                If Tuyen = "Cấp cứu" Then
                    Select Case Mid(Mathe, 1, 1)
                        Case 1 : PhantramDCT = 0
                        Case 2 : PhantramDCT = 0
                        Case 3 : PhantramDCT = 0
                        Case 4 : PhantramDCT = 5
                        Case 5 : PhantramDCT = 5
                        Case 6 : PhantramDCT = 20
                        Case 7 : PhantramDCT = 20
                        Case 9 : PhantramDCT = 0
                    End Select
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function Get_PhanTramDCT(ByVal MaDTThe As String, ByVal Mathe As String, ByVal Tuyen As String, ByVal HanTu As String) As Double
        'Hàm lấy phần trăm đồng chi trả theo mức quyền lợi, loại thẻ mới hay cũ, đúng tuyến , cấp cứu hay trái tuyến
        Try
            Get_PhanTramDCT = 0
            If Len(Mathe) = 13 Then
                Dim Cmd As SqlCommand
                Cmd = New SqlCommand("", Cn)

                If Tuyen = "Đúng tuyến" Or Tuyen = "Cấp cứu" Then
                    Cmd.CommandText = "select dbo.PhantramBHYTTT ('" & MaDTThe & "','" & Mathe & "',0,'" & HanTu & "')"
                End If
                If Tuyen = "Trái tuyến" Then
                    'Get_PhanTramDCT = (PhanTram_TraiTuyen / 100) * (100 - Get_PhanTramDCT)
                    Cmd.CommandText = "select dbo.PhantramBHYTTT ('" & MaDTThe & "','" & Mathe & "',1,'" & HanTu & "')"
                End If
                Get_PhanTramDCT = Cmd.ExecuteScalar()
                If (Get_PhanTramDCT = 66) Then
                    Get_PhanTramDCT = 66.5
                End If
                Cmd.Dispose()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Sub DaInPhieuTTRVBHYT(ByVal makb As String)
        Dim Cmd As SqlCommand
        Try
            Cmd = New SqlCommand("", Cn)
            Cmd.CommandText = String.Format("Update " & TenDatabase & ".DBO.tblThanhtoanBHYT   set Dainphieu = 1 " _
            & " WHERE  Makhambenh='{0}'", makb)
            Cmd.ExecuteNonQuery()
            Cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AutoFill_MaphieuCD(ByVal Loaiphieu As String, ByRef txt As TextBox)
        If txt.Text.Trim() = "" Then Exit Sub
        Select Case Len(Trim(txt.Text))
            Case 1
                txt.Text = Loaiphieu + Format(GetSrvDate(), "yyMMdd") + "000" + txt.Text
            Case 2
                txt.Text = Loaiphieu + Format(GetSrvDate(), "yyMMdd") + "00" + txt.Text
            Case 3
                txt.Text = Loaiphieu + Format(GetSrvDate(), "yyMMdd") + "0" + txt.Text
            Case 4
                txt.Text = Loaiphieu + Format(GetSrvDate(), "yyMMdd") + txt.Text
        End Select
    End Sub
    Function TenABC(ByVal hoten As String) As String
        Dim i
        Dim kytu, vt
        Dim tenmoi As String = ""
        Const vn3 = " ­¨¨¸«»×÷©¬®µ¶·¼½¾¹ªáâäãåæà?çÇçÐéÉÈèÊêëËíÌìÎîÏïÑñÓóÒà?òÔôöÖÕõØøßþÞþúùûÜÜüÝý¦¡¡ ?¤»×÷¢¥§µ¶·¼½¾¹£áâäãåæÆçÇà?ÐéÉÈèÊêëËíÌìÎîÏïÑñÓóÒòòÔà?öÖÕõØøßþÞþúùûÜÜüÝý"
        Const vn3h = " ¦¡¡¸¤»×÷¢¥§µ¶·¼½¾¹£áâäãåæ ÆçÇçÐéÉÈèÊêëËíÌìÎîÏïÑñÓóÒ òòÔôöÖÕõØøßþÞþúùûÜÜüÝý¦¡¡ ¸¤»×÷¢¥§µ¶·¼½¾¹£áâäãåæÆçÇ çÐéÉÈèÊêëËíÌìÎîÏïÑñÓóÒòòÔ ôöÖÕõØøßþÞþúùûÜÜüÝý"
        Const vn3t = " ­¨¨¸«»×÷©¬®µ¶·¼½¾¹ªáâäãåæà?çÇçÐéÉÈèÊêëËíÌìÎîÏïÑñÓóÒà?òÔôöÖÕõØøßþÞþúùûÜÜüÝý­¨¨¸ «»×÷©¬®µ¶·¼½¾¹ªáâäãåæÆçÇç ÐéÉÈèÊêëËíÌìÎîÏïÑñÓóÒòòÔô öÖÕõØøßþÞþúùûÜÜüÝý"
        TenABC = ""
        If Trim(hoten) = "" Then Exit Function
        hoten = " " & hoten.Trim()
        For i = 2 To Len(hoten)
            kytu = Mid(hoten, i, 1)
            vt = InStr(1, vn3, kytu)
            If vt = 0 Then
                If Mid(hoten, i - 1, 1) = " " Then
                    tenmoi = tenmoi & UCase(kytu)
                Else
                    tenmoi = tenmoi & LCase(kytu)
                End If
            Else
                If Mid(hoten, i - 1, 1) = " " Then
                    tenmoi = tenmoi & Mid(vn3h, vt, 1)
                Else
                    tenmoi = tenmoi & Mid(vn3t, vt, 1)
                End If
            End If
        Next
        TenABC = tenmoi
    End Function
    Public Sub MakeDir(ByVal dirName As String)

        Dim reqFTP As FtpWebRequest
        Try

            ' dirName = name of the directory to create.
            reqFTP = FtpWebRequest.Create(New Uri("ftp://" + ftpServerIP + "/" + dirName))
            reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory
            reqFTP.UseBinary = True
            reqFTP.Credentials = New NetworkCredential(ftpUserID, ftpPassword)
            Dim response As FtpWebResponse = reqFTP.GetResponse()
            Dim ftpStream As Stream = response.GetResponseStream()
            ftpStream.Close()
            response.Close()
        Catch ex As Exception
            If ex.Message <> "The remote server returned an error: (550) File unavailable (e.g., file not found, no access)." Then
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub
    Public Sub Upload(ByVal Dir As String, ByVal filename As String)

        Dim fileInf As FileInfo = New FileInfo(filename)
        Dim uri As String = "ftp://" + ftpServerIP + IIf(Dir.ToString <> "", "/" + Dir.Trim, "") + "/" + fileInf.Name
        Dim reqFTP As FtpWebRequest

        ' Create FtpWebRequest object from the Uri provided
        reqFTP = FtpWebRequest.Create(New Uri("ftp://" + ftpServerIP + IIf(Dir.ToString <> "", "/" + Dir.Trim, "") + "/" + fileInf.Name))
        ' Provide the WebPermission Credintials
        reqFTP.Credentials = New NetworkCredential(ftpUserID, ftpPassword)
        ' By default KeepAlive is true, where the control connection is not closed

        ' after a command is executed.
        reqFTP.KeepAlive = False

        ' Specify the command to be executed.
        reqFTP.Method = WebRequestMethods.Ftp.UploadFile

        ' Specify the data transfer type.
        reqFTP.UseBinary = True

        ' Notify the server about the size of the uploaded file
        reqFTP.ContentLength = fileInf.Length

        ' The buffer size is set to 2kb
        Dim buffLength As Integer = 2048
        Dim buff(2048) As Byte
        Dim contentLen As Integer

        ' Opens a file stream (System.IO.FileStream) to read the file to be uploaded
        Dim fs As FileStream = fileInf.OpenRead()

        Try

            ' Stream to which the file to be upload is written
            Dim strm As Stream = reqFTP.GetRequestStream()

            ' Read from the file stream 2kb at a time
            contentLen = fs.Read(buff, 0, buffLength)

            '  Till Stream content ends
            While contentLen <> 0
                ' Write Content from the file stream to the FTP Upload Stream
                strm.Write(buff, 0, contentLen)
                contentLen = fs.Read(buff, 0, buffLength)
            End While

            ' Close the file stream and the Request Stream
            strm.Close()
            fs.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Upload Error")
        End Try
    End Sub
    Public Sub Download(ByVal filePath As String, ByVal Dir As String, ByVal fileName As String)
        Dim reqFTP As FtpWebRequest
        Try

            'filePath = <<The full path where the file is to be created.>>, 
            'fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
            Dim outputStream As FileStream = New FileStream(filePath + "\\" + fileName, FileMode.Create)
            reqFTP = FtpWebRequest.Create(New Uri("ftp://" + ftpServerIP + IIf(Dir.ToString <> "", "/" + Dir.Trim, "") + "/" + fileName))
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile
            reqFTP.UseBinary = True
            reqFTP.Credentials = New NetworkCredential(ftpUserID, ftpPassword)
            Dim response As FtpWebResponse = reqFTP.GetResponse()
            Dim ftpStream As Stream = response.GetResponseStream()
            Dim cl As Long = response.ContentLength
            Dim bufferSize As Integer = 2048
            Dim readCount As Integer
            Dim buffer(bufferSize) As Byte

            readCount = ftpStream.Read(buffer, 0, bufferSize)
            While readCount > 0
                outputStream.Write(buffer, 0, readCount)
                readCount = ftpStream.Read(buffer, 0, bufferSize)
            End While
            ftpStream.Close()
            outputStream.Close()
            response.Close()
        Catch ex As Exception
            If ex.Message <> "The remote server returned an error: (550) File unavailable (e.g., file not found, no access)." Then MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub DeleteFTP(ByVal fileName As String)
        Try

            Dim uri As String = "ftp://" + ftpServerIP + "/" + fileName
            Dim reqFTP As FtpWebRequest
            reqFTP = FtpWebRequest.Create(New Uri("ftp://" + ftpServerIP + "/" + fileName))

            reqFTP.Credentials = New NetworkCredential(ftpUserID, ftpPassword)
            reqFTP.KeepAlive = False
            reqFTP.Method = WebRequestMethods.Ftp.DeleteFile

            Dim result As String = String.Empty
            Dim response As FtpWebResponse = reqFTP.GetResponse()
            Dim size As Long = response.ContentLength
            Dim datastream As Stream = response.GetResponseStream()
            Dim sr As StreamReader = New StreamReader(datastream)
            result = sr.ReadToEnd()
            sr.Close()
            datastream.Close()
            response.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "FTP 2.0 Delete")
        End Try
    End Sub

    Public Sub Rename(ByVal currentFilename As String, ByVal newFilename As String)

        Dim reqFTP As FtpWebRequest
        Try

            reqFTP = FtpWebRequest.Create(New Uri("ftp://" + ftpServerIP + "/" + currentFilename))
            reqFTP.Method = WebRequestMethods.Ftp.Rename
            reqFTP.RenameTo = newFilename
            reqFTP.UseBinary = True
            reqFTP.Credentials = New NetworkCredential(ftpUserID, ftpPassword)
            Dim response As FtpWebResponse = reqFTP.GetResponse()
            Dim ftpStream As Stream = response.GetResponseStream()

            ftpStream.Close()
            response.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function GetFileList(ByVal Dir As String) As String()

        Dim downloadFiles As String()
        Dim result As StringBuilder = New StringBuilder()
        Dim reqFTP As FtpWebRequest
        Try

            reqFTP = FtpWebRequest.Create(New Uri("ftp://" + ftpServerIP + IIf(Dir.ToString <> "", "/" + Dir.Trim + "/", "/")))
            reqFTP.UseBinary = True
            reqFTP.Credentials = New NetworkCredential(ftpUserID, ftpPassword)
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectory
            Dim response As WebResponse = reqFTP.GetResponse()
            Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
            'MessageBox.Show(reader.ReadToEnd());
            Dim line As String = reader.ReadLine()
            While line <> Nothing
                result.Append(line)
                result.Append(Chr(13))
                line = reader.ReadLine()
            End While
            result.Remove(result.ToString().LastIndexOf(Chr(13)), 1)
            reader.Close()
            response.Close()
            'MessageBox.Show(response.StatusDescription);
            Return result.ToString().Split(Chr(13))
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
            downloadFiles = Nothing
            Return downloadFiles
        End Try
    End Function

    Public Function File_Ftp_Exists(ByVal Parent_Dir As String, ByVal Child_Dir As String) As Boolean
        'Hàm kiểm tra xem Child_Dir (bao gồm cả file và thư mục) đã có trong thư mục Parent_Dir chưa
        Try
            File_Ftp_Exists = False
            Dim filenames As String() = GetFileList(Parent_Dir)
            For Each filename In filenames
                If filename = Child_Dir Then ' Nếu có
                    File_Ftp_Exists = True
                    Exit Function
                End If
            Next
        Catch EX As Exception
        End Try
    End Function
    Public Sub Grid2Table(ByVal Grd As C1FlexGrid)
        Dim i, j As Integer
        Dim SQL As String
        Dim cmd As New SqlCommand

        If Grd.Rows.Count = Grd.Rows.Fixed Then Exit Sub
        SQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[temp_Table]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[temp_Table]"
        cmd = New SqlCommand(SQL, Cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        SQL = "CREATE TABLE [dbo].[temp_Table] (  "
        For i = 0 To Grd.Cols.Count - 1
            If Grd.Cols(i).Visible Then
                SQL = SQL + "[" + Grd.Item(Grd.Rows.Fixed - 1, i) + "] [nvarchar] (500) NULL,"
            End If
        Next
        SQL = SQL.Substring(0, SQL.Length - 1) + ")"
        cmd = New SqlCommand(SQL, Cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        For i = Grd.Rows.Fixed To Grd.Rows.Count - 1
            SQL = "insert into temp_Table values ( "
            For j = 0 To Grd.Cols.Count - 1
                If Grd.Cols(j).Visible = True Then
                    SQL = SQL + "N'" & Grd.Item(i, j) & "',"
                End If
            Next
            SQL = SQL.Substring(0, SQL.Length - 1) + ")"
            cmd = New SqlCommand(SQL, Cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Next
    End Sub

    Public Sub Grid2Table_Row_Hide(ByVal Grd As C1FlexGrid)
        Dim i, j As Integer
        Dim SQL As String
        Dim cmd As New SqlCommand

        If Grd.Rows.Count = Grd.Rows.Fixed Then Exit Sub
        SQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[temp_Table]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[temp_Table]"
        cmd = New SqlCommand(SQL, Cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        SQL = "CREATE TABLE [dbo].[temp_Table] (  "
        For i = 0 To Grd.Cols.Count - 1
            If Grd.Cols(i).Visible Then
                SQL = SQL + "[" + Grd.Item(Grd.Rows.Fixed - 1, i) + "] [nvarchar] (500) NULL,"
            End If
        Next
        SQL = SQL.Substring(0, SQL.Length - 1) + ")"
        cmd = New SqlCommand(SQL, Cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        For i = Grd.Rows.Fixed To Grd.Rows.Count - 1
            If Grd.Rows(i).Visible = True Then
                SQL = "insert into temp_Table values ( "
                For j = 0 To Grd.Cols.Count - 1
                    If Grd.Cols(j).Visible = True Then
                        SQL = SQL + "N'" & Grd.Item(i, j) & "',"
                    End If
                Next
                SQL = SQL.Substring(0, SQL.Length - 1) + ")"
                cmd = New SqlCommand(SQL, Cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
        Next
    End Sub
    Public Sub BindDatareaderToGrid(ByVal fg As C1.Win.C1FlexGrid.C1FlexGrid, ByVal dr As System.Data.SqlClient.SqlDataReader)
        fg.Redraw = False
        fg.Tag = "0"
        fg.Rows.Count = 1
        Dim row As Integer = 0
        While dr.Read()
            fg.AddItem("")
            row = fg.Rows.Count - 1
            Dim i As Integer = 0
            While i < dr.FieldCount
                fg(row, dr.GetName(i)) = dr(i)
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
        End While
        fg.AutoSizeCols(0, fg.Cols.Count - 1, 1)
        fg.Row = -1
        fg.Tag = "1"
        fg.Redraw = True
    End Sub
    Public Function GetCode(ByVal cmb As C1.Win.C1List.C1Combo) As String
        Dim tmp As String
        tmp = cmb.Columns(0).CellText(cmb.SelectedIndex)
        If tmp = "" Then
            tmp = Nothing
        End If
        Return tmp
    End Function

    Public Sub SetCmb(ByVal cmb As C1.Win.C1List.C1Combo, ByVal itemvalue As String)
        cmb.SelectedIndex = cmb.FindStringExact(itemvalue, 0, 0)
    End Sub


    ' Verify a hash against a string.
    Public Function verifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        Dim hashOfInput As String = getMd5Hash(input)
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function LayRiengTen(ByVal tendu As String) As String
        Dim i
        Try
            If IsDBNull(tendu) Then tendu = ""
            tendu = tendu.Trim()
            LayRiengTen = tendu
            If tendu = "" Then Exit Function
            For i = tendu.Length - 1 To 0 Step -1
                If tendu.Substring(i, 1) = " " Then ' i la vị trí có ký tự trắng cuối cùng
                    LayRiengTen = tendu.Substring(i + 1)
                    Exit Function
                End If
            Next
        Catch ex As Exception
        End Try
    End Function

    Public Sub Save_Text(ByVal mForm As Form, ByVal Lang As String, ByVal connect As SqlClient.SqlConnection)
        '''Dim control_list = GetAll(mForm)
        ''Dim sqlCmd As SqlCommand = New SqlCommand("", connect)
        ''sqlCmd.CommandText = "DELETE FROM tblCONTROLS WHERE Form_Name='" & mForm.Name & "'"
        ''sqlCmd.ExecuteNonQuery()

        ''sqlCmd.CommandText = "INSERT INTO tblCONTROLS (Form_Name,Control_Name,Control_Type,vi) VALUES (@Form_Name,@Control_Name,@Control_Type, @vi)"
        ''sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
        ''sqlCmd.Parameters.AddWithValue("@Control_Name", mForm.Name)
        ''sqlCmd.Parameters.AddWithValue("@Control_Type", "FORM")
        ''sqlCmd.Parameters.AddWithValue("@vi", mForm.Text)
        ''sqlCmd.ExecuteNonQuery()
        ''sqlCmd.Parameters.Clear()

        ''For Each b As Control In mForm.Controls ' control_list
        ''    If b.Controls.Count > 0 Then
        ''        For Each c As Control In b.Controls
        ''            If types.Contains(c.[GetType]()) Then
        ''                'sqlCmd.CommandText = "INSERT INTO tblCONTROLS (Form_Name,Control_Name,Control_Type,vi) VALUES (@Form_Name,@Control_Name,@Control_Type, @vi)"
        ''                sqlCmd.CommandText = "pr_tblControls_Insert"
        ''                sqlCmd.CommandType = CommandType.StoredProcedure
        ''                sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
        ''                sqlCmd.Parameters.AddWithValue("@Control_Name", c.Name)
        ''                sqlCmd.Parameters.AddWithValue("@Control_Type", c.[GetType]().ToString())
        ''                sqlCmd.Parameters.AddWithValue("@vi", c.Text)
        ''                sqlCmd.ExecuteNonQuery()
        ''                sqlCmd.Parameters.Clear()
        ''            End If
        ''        Next
        ''    End If

        ''    If types.Contains(b.[GetType]()) Then
        ''        'sqlCmd.CommandText = "INSERT INTO tblCONTROLS (Form_Name,Control_Name,Control_Type,vi) VALUES (@Form_Name,@Control_Name,@Control_Type, @vi)"
        ''        sqlCmd.CommandText = "pr_tblControls_Insert"
        ''        sqlCmd.CommandType = CommandType.StoredProcedure
        ''        sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
        ''        sqlCmd.Parameters.AddWithValue("@Control_Name", b.Name)
        ''        sqlCmd.Parameters.AddWithValue("@Control_Type", b.[GetType]().ToString())
        ''        sqlCmd.Parameters.AddWithValue("@vi", b.Text)
        ''        sqlCmd.ExecuteNonQuery()
        ''        sqlCmd.Parameters.Clear()
        ''    End If
        ''    'MessageBox.Show(String.Format("Type: {0}  -  Name: {1}  -  Text: {2}", b.[GetType](), b.Name, b.Text))
        ''Next

        Dim controls As IEnumerable(Of Control) = mForm.Controls.Cast(Of Control)()
        Dim control_list = controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)
        sqlCmd.CommandText = "DELETE FROM tblCONTROLS WHERE Form_Name='" & mForm.Name & "'  AND isnull(en,'') = ''"
        sqlCmd.ExecuteNonQuery()
        For Each b As Control In control_list
            If b.Text.Trim <> "" And b.Visible = True Then
                ' sqlCmd.CommandText = "INSERT INTO tblCONTROLS (Form_Name,Control_Name,Control_Type,vi) VALUES (@Form_Name,@Control_Name,@Control_Type, @vi)"
                sqlCmd.CommandText = "pr_tblControls_Insert"
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
                sqlCmd.Parameters.AddWithValue("@Control_Name", b.Name)
                sqlCmd.Parameters.AddWithValue("@Control_Type", b.[GetType]().ToString())
                sqlCmd.Parameters.AddWithValue("@vi", b.Text)
                sqlCmd.ExecuteNonQuery()
                sqlCmd.Parameters.Clear()
                If b.Controls.Count > 0 Then
                    Dim childs As IEnumerable(Of Control) = b.Controls.Cast(Of Control)()
                    Dim child_list = childs.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(childs).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))
                    For Each ch As Control In child_list
                        If ch.Text.Trim <> "" And ch.Visible = True Then
                            sqlCmd.CommandText = "pr_tblControls_Insert"
                            sqlCmd.CommandType = CommandType.StoredProcedure
                            sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
                            sqlCmd.Parameters.AddWithValue("@Control_Name", ch.Name)
                            sqlCmd.Parameters.AddWithValue("@Control_Type", ch.[GetType]().ToString())
                            sqlCmd.Parameters.AddWithValue("@vi", ch.Text)
                            sqlCmd.ExecuteNonQuery()
                            sqlCmd.Parameters.Clear()
                        End If

                    Next
                End If
            End If
        Next

        sqlCmd.Dispose()
    End Sub
    Public Sub Save_Text_Report(ByVal mForm As DataDynamics.ActiveReports.ActiveReport3, ByVal nameReport As String, ByVal Lang As String, ByVal connect As SqlClient.SqlConnection)
        Dim controls = mForm.Sections("ReportHeader1").Controls '.Cast(Of Control)()
        'Dim control_list = controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)
        'sqlCmd.CommandText = "DELETE FROM tblCONTROLS WHERE Form_Name='" & mForm.Name & "'  AND isnull(en,'') = ''"
        'sqlCmd.ExecuteNonQuery()
        Dim i As Integer
        i = 0
        For i = 0 To controls.Count - 1
            If controls(i).[GetType]().ToString() = "DataDynamics.ActiveReports.Label" And controls(i).Text IsNot Nothing Then
                sqlCmd.CommandText = "pr_tblControls_Insert"
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Form_Name", nameReport)
                sqlCmd.Parameters.AddWithValue("@Control_Name", controls(i).Name)
                sqlCmd.Parameters.AddWithValue("@Control_Type", controls(i).[GetType]().ToString())
                sqlCmd.Parameters.AddWithValue("@vi", controls(i).Text)
                sqlCmd.ExecuteNonQuery()
                sqlCmd.Parameters.Clear()
            End If

        Next

        controls = mForm.Sections("ReportFooter1").Controls '.Cast(Of Control)()
        'Dim control_list = controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))

        For i = 0 To controls.Count - 1
            If controls(i).[GetType]().ToString() = "DataDynamics.ActiveReports.Label" And controls(i).Text IsNot Nothing Then
                sqlCmd.CommandText = "pr_tblControls_Insert"
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Form_Name", nameReport)
                sqlCmd.Parameters.AddWithValue("@Control_Name", controls(i).Name)
                sqlCmd.Parameters.AddWithValue("@Control_Type", controls(i).[GetType]().ToString())
                sqlCmd.Parameters.AddWithValue("@vi", controls(i).Text)
                sqlCmd.ExecuteNonQuery()
                sqlCmd.Parameters.Clear()
            End If
        Next

        'For Each b As Control In controls
        '    If b.Text.Trim <> "" And b.Visible = True Then
        '        ' sqlCmd.CommandText = "INSERT INTO tblCONTROLS (Form_Name,Control_Name,Control_Type,vi) VALUES (@Form_Name,@Control_Name,@Control_Type, @vi)"
        '        sqlCmd.CommandText = "pr_tblControls_Insert"
        '        sqlCmd.CommandType = CommandType.StoredProcedure
        '        sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
        '        sqlCmd.Parameters.AddWithValue("@Control_Name", b.Name)
        '        sqlCmd.Parameters.AddWithValue("@Control_Type", b.[GetType]().ToString())
        '        sqlCmd.Parameters.AddWithValue("@vi", b.Text)
        '        sqlCmd.ExecuteNonQuery()
        '        sqlCmd.Parameters.Clear()
        '        '    If b.Controls.Count > 0 Then
        '        '        Dim childs As IEnumerable(Of Control) = b.Controls.Cast(Of Control)()
        '        '        Dim child_list = childs.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(childs).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))
        '        '        For Each ch As Control In child_list
        '        '            If ch.Text.Trim <> "" And ch.Visible = True Then
        '        '                sqlCmd.CommandText = "pr_tblControls_Insert"
        '        '                sqlCmd.CommandType = CommandType.StoredProcedure
        '        '                sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
        '        '                sqlCmd.Parameters.AddWithValue("@Control_Name", ch.Name)
        '        '                sqlCmd.Parameters.AddWithValue("@Control_Type", ch.[GetType]().ToString())
        '        '                sqlCmd.Parameters.AddWithValue("@vi", ch.Text)
        '        '                sqlCmd.ExecuteNonQuery()
        '        '                sqlCmd.Parameters.Clear()
        '        '            End If

        '        '        Next
        '        '    End If
        '    End If
        'Next

        sqlCmd.Dispose()
    End Sub
    Public Sub Save_Text_Grid(ByVal mForm As Form, ByVal grView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Lang As String, ByVal connect As SqlClient.SqlConnection)
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)
        sqlCmd.CommandText = "DELETE FROM tblCONTROLS WHERE Form_Name='" & mForm.Name & "'  AND isnull(en,'') = ''"
        sqlCmd.ExecuteNonQuery()
        For Each cl As DevExpress.XtraGrid.Columns.GridColumn In grView.Columns
            If cl.Caption.Trim <> "" And cl.Visible = True Then
                sqlCmd.CommandText = "pr_tblControls_Insert"
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
                sqlCmd.Parameters.AddWithValue("@Control_Name", cl.Name)
                sqlCmd.Parameters.AddWithValue("@Control_Type", cl.[GetType]().ToString())
                sqlCmd.Parameters.AddWithValue("@vi", cl.Caption)
                sqlCmd.ExecuteNonQuery()
                sqlCmd.Parameters.Clear()
            End If
        Next
        sqlCmd.Dispose()
    End Sub
    Public Sub Save_Text_FlexGrid(ByVal mForm As Form, ByVal grView As C1.Win.C1FlexGrid.C1FlexGrid, ByVal Lang As String, ByVal connect As SqlClient.SqlConnection)
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)
        'sqlCmd.CommandText = "DELETE FROM tblCONTROLS WHERE Form_Name='" & mForm.Name & "'  AND isnull(en,'') = ''"
        'sqlCmd.ExecuteNonQuery()
        For Each cl As C1.Win.C1FlexGrid.Column In grView.Cols
            If cl.Caption.Trim <> "" And cl.Visible = True Then
                sqlCmd.CommandText = "pr_tblControls_Insert"
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Form_Name", mForm.Name)
                sqlCmd.Parameters.AddWithValue("@Control_Name", cl.Name)
                sqlCmd.Parameters.AddWithValue("@Control_Type", cl.[GetType]().ToString())
                sqlCmd.Parameters.AddWithValue("@vi", cl.Caption)
                sqlCmd.ExecuteNonQuery()
                sqlCmd.Parameters.Clear()
            End If
        Next
        sqlCmd.Dispose()
    End Sub
    Public Function GetAll(ByVal control As Control) As IEnumerable(Of Control)
        Dim controls As IEnumerable(Of Control) = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) types.Contains(c.[GetType]()))
        'Return controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) c.GetType())
    End Function
    Public types As List(Of Type) = New List(Of Type)() From {
        GetType(Button),
        GetType(Label),
        GetType(RadioButton),
        GetType(GroupBox),
        GetType(Panel),
        GetType(LinkLabel),
        GetType(CheckBox),
        GetType(TabControl),
        GetType(TabPage),
        GetType(ToolStripItem),
        GetType(ToolStripMenuItem),
        GetType(MenuStrip),
        GetType(DevExpress.XtraNavBar.NavBarControl),
        GetType(DevExpress.XtraNavBar.NavBarGroup),
        GetType(DevExpress.XtraNavBar.NavBarItem),
        GetType(DevExpress.XtraEditors.SimpleButton),
        GetType(DevExpress.XtraGrid.Views.Grid.GridView),
        GetType(DataDynamics.ActiveReports.Label)
    }
    Public Class fControl
        Public Property Control_Name As String
        Public Property Control_Type As String
        Public Property Control_Text As String
    End Class
    Public Function Set_Text(ByVal mform As Form, ByVal lang As String) As Boolean
        Dim resultList As List(Of fControl) = New List(Of fControl)()
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)

        sqlCmd.CommandText = "SELECT * FROM tblCONTROLS WHERE Form_Name='" & mform.Name & "'"
        Dim dr As SqlDataReader = sqlCmd.ExecuteReader()

        While dr.Read()
            Dim sname = dr("Control_Name").ToString()
            Dim controls As IEnumerable(Of Control) = mform.Controls.Cast(Of Control)()
            Dim control_list = controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))
            If sname = mform.Name Then
                mform.Text = dr(lang).ToString()
            End If
            For Each b As Control In control_list ' control_list
                If b.Controls.Count > 0 Then
                    Dim childs As IEnumerable(Of Control) = b.Controls.Cast(Of Control)()
                    Dim child_list = childs.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(childs).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))
                    For Each c As Control In child_list
                        If types.Contains(c.[GetType]()) Then
                            If c.Name = sname Then
                                c.Text = dr(lang).ToString()
                                'If lang = "my" Then
                                '    c.Font = New Font("Microsoft Sans Serif", 13, FontStyle.Regular)
                                'End If
                            End If
                        End If
                    Next
                End If

                If types.Contains(b.[GetType]()) Then
                    If b.Name = sname Then
                        b.Text = dr(lang).ToString()
                    End If
                End If
                'MessageBox.Show(String.Format("Type: {0}  -  Name: {1}  -  Text: {2}", b.[GetType](), b.Name, b.Text))
            Next


        End While

        dr.Close()
        sqlCmd.Dispose()
        Return (True)
    End Function

    Public Function Set_Text_Grid(ByVal mform As Form, ByVal grView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal lang As String) As Boolean
        Dim resultList As List(Of fControl) = New List(Of fControl)()
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)

        sqlCmd.CommandText = "SELECT * FROM tblCONTROLS WHERE Form_Name='" & mform.Name & "' AND Control_Type = 'DevExpress.XtraGrid.Columns.GridColumn'"
        Dim dr As SqlDataReader = sqlCmd.ExecuteReader()

        While dr.Read()
            Dim sname = dr("Control_Name").ToString()
            Dim controls As IEnumerable(Of Control) = mform.Controls.Cast(Of Control)()
            Dim control_list = controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))

            For Each cl As DevExpress.XtraGrid.Columns.GridColumn In grView.Columns ' control_list
                If cl.Name = sname Then
                    cl.Caption = dr(lang).ToString()
                End If
            Next


        End While

        dr.Close()
        sqlCmd.Dispose()
        Return (True)
    End Function

    Public Function Set_Text_FlexGrid(ByVal mform As Form, ByVal grView As C1.Win.C1FlexGrid.C1FlexGrid, ByVal lang As String) As Boolean
        Dim resultList As List(Of fControl) = New List(Of fControl)()
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)

        sqlCmd.CommandText = "SELECT * FROM tblCONTROLS WHERE Form_Name='" & mform.Name & "' AND Control_Type = 'C1.Win.C1FlexGrid.Column'"
        Dim dr As SqlDataReader = sqlCmd.ExecuteReader()

        While dr.Read()
            Dim sname = dr("Control_Name").ToString()
            Dim controls As IEnumerable(Of Control) = mform.Controls.Cast(Of Control)()
            Dim control_list = controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) mdlFunction.types.Contains(c.[GetType]()))

            For Each cl As C1.Win.C1FlexGrid.Column In grView.Cols ' control_list
                If cl.Name = sname Then
                    cl.Caption = dr(lang).ToString()
                End If
            Next


        End While

        dr.Close()
        sqlCmd.Dispose()
        Return (True)
    End Function
    Public Function Set_Text_Report(ByVal mform As DataDynamics.ActiveReports.ActiveReport3, ByVal nameReport As String, ByVal lang As String) As Boolean
        Dim resultList As List(Of fControl) = New List(Of fControl)()
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)

        sqlCmd.CommandText = "SELECT * FROM tblCONTROLS WHERE Form_Name='" & nameReport & "'"
        Dim dr As SqlDataReader = sqlCmd.ExecuteReader()

        While dr.Read()
            Dim sname = dr("Control_Name").ToString()
            Dim controls = mform.Sections("ReportHeader1").Controls
            Dim i = 0
            For i = 0 To controls.Count - 1
                If controls(i).Name = sname Then
                    controls(i).Text = dr(lang).ToString()
                End If
            Next

            controls = mform.Sections("ReportFooter1").Controls
            For i = 0 To controls.Count - 1
                If controls(i).Name = sname Then
                    controls(i).Text = dr(lang).ToString()
                End If
            Next
        End While

        dr.Close()
        sqlCmd.Dispose()
        Return (True)
    End Function
End Module
