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
Public Class frmQuanTriNguoiDung
    Dim tmpPic As PictureBox
    Private Sub frmQuanLyNhom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strSQL As String = ""
        Dim GroupStyle As C1.Win.C1FlexGrid.CellStyle = fgFunct.Styles.Add("GroupStyle")
        GroupStyle.BackColor = Color.LightBlue
        '			GroupStyle.ForeColor = Color.Gold;
        GroupStyle.Font = New Font(fgFunct.Font, FontStyle.Bold)
        strSQL = "SELECT SYSUSER.* FROM SYSUSER"
        Dim cmd As New System.Data.SqlClient.SqlCommand(strSQL, Cn)
        Dim rd As System.Data.SqlClient.SqlDataReader
        rd = cmd.ExecuteReader()
        fgUser.ClipSeparators = "|;"
        fgUser.Tag = "0"
        fgUser.Rows.Count = 1
        While rd.Read()
            fgUser.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", rd("UName"), Enc.EncDec.DecryptPassword(rd("Pass").ToString()), rd("TenDu"), "", "", _
             rd("quyen")))
        End While
        rd.Close()
        fgUser.Row = 0
        fgUser.Tag = "1"
        fgUser.Cols(1).Visible = False
        fgUser.Cols(3).Visible = False
        cmd.CommandText = "SELECT * FROM DMKHOAPHONG ORDER BY MaKhoa"
        rd = cmd.ExecuteReader()
        fg.ClipSeparators = "|;"
        fg.Rows.Count = 1
        cmbKhoa.ClearItems()
        While rd.Read()
            fg.AddItem(String.Format("{0}|{1}", rd("MaKhoa"), rd("TenKhoa")))
            cmbKhoa.AddItem(rd("MaKhoa").ToString() + ";" + rd("TenKhoa").ToString())
        End While
        rd.Close()
        cmbChuongTrinh.Tag = "0"

        strSQL = "SELECT * FROM HIS_APPLICATIONs WHERE MaCT = '02' ORDER By MaCT"
        cmd.CommandText = strSQL
        rd = cmd.ExecuteReader()
        cmbChuongTrinh.ClearItems()
        While rd.Read()
            cmbChuongTrinh.AddItem(String.Format("{0};{1}", rd("maCT"), rd("TenCT")))
        End While
        rd.Close()
        cmbChuongTrinh.Tag = "1"
        cmbKhoa.SelectedIndex = -1
        cmd.Dispose()
        fgUser.AutoSizeCols(0, 2, 1)
        fg.AutoSizeCols(0, 2, 1)
        fg.AllowEditing = True
        fg.Cols(0).AllowEditing = False
        fg.Cols(1).AllowEditing = False
        picChuKy.Image = imageList1.Images(0)
        picChuKy.Tag = ""
        picAnhNguoiDung.ContextMenuStrip = menuChonAnh
        picChuKy.ContextMenuStrip = menuChonAnh

        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, fgUser, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, fgFunct, Lang)
        Load_ChucNang(uName)
    End Sub
    Private Sub Load_ChucNang(ByVal uName As String)
        Dim MaCT As String = GetCode(cmbChuongTrinh)
        If MaCT = Nothing OrElse cmbChuongTrinh.Tag.ToString() = "0" Then
            Return
        End If
        Dim cmd As New System.Data.SqlClient.SqlCommand()
        cmd.Connection = Cn
        cmd.CommandText = "SELECT * FROM FUNCTIONS WHERE MaCT='" + MaCT + "' ORDER BY FuncID"
        Dim rd As System.Data.SqlClient.SqlDataReader
        rd = cmd.ExecuteReader()
        fgFunct.ClipSeparators = "|;"
        fgFunct.Rows.Count = 1
        While rd.Read()
            fgFunct.AddItem(String.Format("{0}|{1}|{2}", fgFunct.Rows.Count, rd("FuncID"), rd("FuncText")))
            If rd("FuncID").ToString().Substring(1) = "00" Then
                fgFunct.Rows(fgFunct.Rows.Count - 1).AllowEditing = False
                fgFunct.Rows(fgFunct.Rows.Count - 1).Style = fgFunct.Styles("GroupStyle")
            End If
        End While
        rd.Close()
        Dim i As Integer = 0
        i = 1
        While i < fgFunct.Rows.Count
            fgFunct(i, 3) = "False"
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        cmd.CommandText = "SELECT * FROM USER_FUNCTION WHERE UName='" + uName + "' AND MaCT='" + MaCT + "'"
        rd = cmd.ExecuteReader()
        While rd.Read()
            i = 1
            While i < fgFunct.Rows.Count
                If fgFunct.GetDataDisplay(i, 1) = rd("FuncID").ToString() Then
                    fgFunct(i, 3) = "True"
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
        End While
        rd.Close()
        cmd.Dispose()
        fgFunct.AllowEditing = True
        fgFunct.Cols(0).AllowEditing = False
        fgFunct.Cols(1).AllowEditing = False
        fgFunct.Cols(2).AllowEditing = False
        fgFunct.Cols(1).Visible = False
    End Sub

    Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles simpleButton1.Click
        Me.Dispose()
    End Sub



    Private Sub cmdThem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        txtFullName.Text = ""
        txtPass.Text = ""
        txtConfirm.Text = ""
        txtUserName.Text = ""
        txtUserName.[ReadOnly] = False
        txtUserName.Focus()
    End Sub

    Private Sub fgUser_AfterRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles fgUser.AfterRowColChange
        If fgUser.Row < 1 OrElse fgUser.Tag.ToString() = "0" Then
            Return
        End If
        Dim uName As String = fgUser.GetDataDisplay(fgUser.Row, 0)
        lblUser.Text = "User Name: " + uName
        txtUserName.Text = uName
        txtFullName.Text = fgUser.GetDataDisplay(fgUser.Row, 2)
        txtPass.Text = fgUser.GetDataDisplay(fgUser.Row, 1)
        txtConfirm.Text = fgUser.GetDataDisplay(fgUser.Row, 1)
        SetCmb(cmbKhoa, fgUser.GetDataDisplay(fgUser.Row, 3))
        If fgUser.GetDataDisplay(fgUser.Row, 5) = "1" Then
            rdAdmin.Checked = True
        Else
            rdUser.Checked = True
        End If
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand()
        SQLCmd.CommandText = "SELECT * FROM USER_KHOA WHERE Uname='" + uName + "'"
        Dim i As Integer = 0
        i = 1
        While i < fg.Rows.Count
            fg(i, 2) = "False"
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        SQLCmd.Connection = Cn
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        Dim MaKhoa As String = ""
        While dr.Read()
            MaKhoa = dr("MaKhoa").ToString()
            i = 1
            While i < fg.Rows.Count
                If fg.GetDataDisplay(i, 0) = MaKhoa Then
                    fg(i, 2) = "True"
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
        End While
        dr.Close()

        fgFunct.Rows.Count = 1
        cmbChuongTrinh.SelectedIndex = -1
        SQLCmd.Dispose()
        If Not txtUserName.[ReadOnly] Then
            txtUserName.[ReadOnly] = True
        End If
        picChuKy.Tag = ""
        'if (LoadChuKy(uName))
        '{
        '    picChuKy.Load(Application.StartupPath + @"\tmpSignal");
        '    picChuKy.Tag = "1";
        '}
        'else
        '{
        '    picChuKy.Image = imageList1.Images[0];
        '}
        'if (LoadAnhNguoiDung(uName))
        '{
        '    picAnhNguoiDung.Load(Application.StartupPath + @"\tmpPicture");
        '    picAnhNguoiDung.Tag = "1";
        '}
        'else
        '{
        '    picAnhNguoiDung.Image = imageList1.Images[1];
        '}
    End Sub

    Private Sub cmdGhiUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGhiUser.Click
        If txtPass.Text <> txtConfirm.Text Then
            MessageBox.Show("Password and confirmation are incorrect, please check again!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If
        'If GetCode(cmbKhoa) = Nothing Then
        '    MessageBox.Show("Chưa chọn Khoa - Phòng cho người dùng, đề nghị kiểm tra lại", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '    Return
        'End If
        Dim MD5Pass As String = ""
        MD5Pass = getMd5Hash(txtPass.Text)
        Dim Nhom As Byte = IIf((rdAdmin.Checked), 1, 2)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand()
        Dim SQLTrn As System.Data.SqlClient.SqlTransaction
        Dim SQLStr As String = ""
        'If txtUserName.[ReadOnly] Then
        '    'Sua
        '    If chkPass_editable.Checked Then
        '        SQLStr = String.Format("UPDATE SYSUSER SET Pass='{0}',TenDu=N'{1}',KhoaPhong='{2}',Quyen={3} WHERE UName='{4}'", MD5Pass, txtFullName.Text, GetCode(cmbKhoa), Nhom, txtUserName.Text)
        '    Else
        '        SQLStr = String.Format("UPDATE SYSUSER SET TenDu=N'{0}',KhoaPhong='{1}',Quyen={2} WHERE UName='{3}'", txtFullName.Text, GetCode(cmbKhoa), Nhom, txtUserName.Text)
        '    End If
        'Else
        '    'Thêm
        '    SQLStr = String.Format("INSERT INTO SYSUSER (UName,Pass,TenDu,KhoaPhong,Quyen) VALUES (N'{0}','{1}',N'{2}','{3}',{4})", txtUserName.Text, MD5Pass, txtFullName.Text, GetCode(cmbKhoa), Nhom)
        'End If
        If txtUserName.[ReadOnly] Then
            'Sua
            If chkPass_editable.Checked Then
                SQLStr = String.Format("UPDATE SYSUSER SET Pass='{0}',TenDu=N'{1}',KhoaPhong='K',Quyen={3} WHERE UName='{4}'", MD5Pass, txtFullName.Text, GetCode(cmbKhoa), Nhom, txtUserName.Text)
            Else
                SQLStr = String.Format("UPDATE SYSUSER SET TenDu=N'{0}',KhoaPhong='K',Quyen={2} WHERE UName='{3}'", txtFullName.Text, GetCode(cmbKhoa), Nhom, txtUserName.Text)
            End If
        Else
            'Thêm
            SQLStr = String.Format("INSERT INTO SYSUSER (UName,Pass,TenDu,KhoaPhong,Quyen) VALUES (N'{0}','{1}',N'{2}','K',{4})", txtUserName.Text, MD5Pass, txtFullName.Text, GetCode(cmbKhoa), Nhom)
        End If
        'SaveSignal(txtUserName.Text);
        SQLTrn = Cn.BeginTransaction()
        SQLCmd.Transaction = SQLTrn

        Try
            SQLCmd.Connection = Cn
            SQLCmd.CommandText = SQLStr
            SQLCmd.ExecuteNonQuery()
            SQLCmd.CommandText = " DELETE FROM USER_KHOA WHERE UName='" + txtUserName.Text + "'"
            SQLCmd.ExecuteNonQuery()
            Dim i As Integer = 1
            While i < fg.Rows.Count
                If fg.GetDataDisplay(i, 2) = "True" Then
                    SQLCmd.CommandText = String.Format("INSERT INTO USER_KHOA (UName,MaKhoa) VALUES ('{0}','{1}')", txtUserName.Text, fg.GetDataDisplay(i, 0))
                    SQLCmd.ExecuteNonQuery()
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            If cmbChuongTrinh.SelectedIndex > -1 Then
                SQLCmd.CommandText = " DELETE FROM USER_FUNCTION WHERE UName='" + txtUserName.Text + "' AND MaCT='" + GetCode(cmbChuongTrinh) + " '"
                SQLCmd.ExecuteNonQuery()
                i = 1
                While i < fgFunct.Rows.Count
                    If fgFunct.GetDataDisplay(i, 3) = "True" Then
                        SQLCmd.CommandText = String.Format("INSERT INTO USER_FUNCTION (UName,FuncID,MaCT) VALUES ('{0}','{1}','{2}')", txtUserName.Text, fgFunct.GetDataDisplay(i, 1), GetCode(cmbChuongTrinh))
                        SQLCmd.ExecuteNonQuery()
                    End If
                    System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
                End While
            End If

            SQLTrn.Commit()
            If Not txtUserName.[ReadOnly] Then
                'Thêm
                fgUser.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", txtUserName.Text, txtPass.Text, txtFullName.Text, GetCode(cmbKhoa), cmbKhoa.Text, _
                 Nhom))
                txtUserName.[ReadOnly] = True
            Else
                'Sửa
                fgUser(fgUser.Row, 2) = txtFullName.Text
                fgUser(fgUser.Row, 1) = txtPass.Text
                fgUser(fgUser.Row, 3) = GetCode(cmbKhoa)
                fgUser(fgUser.Row, 4) = cmbKhoa.Text
                fgUser(fgUser.Row, 5) = Nhom
            End If
            MessageBox.Show("Update successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SQLTrn.Rollback()

            MessageBox.Show("There was an error writing data" & vbLf + ex.Message, "Message")
        Finally
            SQLCmd.Dispose()
            SQLTrn.Dispose()
        End Try
    End Sub

    Private Sub cmdXoaUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdXoaUser.Click
        If txtUserName.Text = "" Then
            Return
        End If
        If MessageBox.Show("Are you sure you want to remove this user from the list??", "Request confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Return
        End If
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand()
        SQLCmd.Connection = Cn
        Dim SQLtrn As System.Data.SqlClient.SqlTransaction
        SQLtrn = Cn.BeginTransaction()
        SQLCmd.Transaction = SQLtrn
        Try
            SQLCmd.CommandText = "DELETE FROM USER_KHOA WHERE UName='" + txtUserName.Text + "'"
            SQLCmd.ExecuteNonQuery()
            SQLCmd.CommandText = "DELETE FROM SYSUSER WHERE UName='" + txtUserName.Text + "'"
            SQLCmd.ExecuteNonQuery()
            SQLtrn.Commit()
            fgUser.RemoveItem(fgUser.Row)
        Catch ex As Exception
            SQLtrn.Rollback()
            MessageBox.Show("An error occurred during execution: " & vbLf + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            SQLCmd.Dispose()
            SQLtrn.Dispose()
        End Try
    End Sub
  

    Private Sub cmbChuongTrinh_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbChuongTrinh.TextChanged
        If cmbChuongTrinh.Tag.ToString() = "0" Then
            Return
        End If
        Dim uName As String = fgUser.GetDataDisplay(fgUser.Row, 0)
        Load_ChucNang(uName)

    End Sub
    Private Function LoadChuKy(ByVal UName As String) As [Boolean]
        Dim FileExists As Boolean = False
        Dim cmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Try
            cmd.CommandText = "SELECT Signal FROM SYSUSER WHERE Uname='" + UName + "'"
            Dim buffer As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            If buffer.Length > 0 Then
                FileExists = True
                Dim OutputStream As Stream = File.OpenWrite(Application.StartupPath + "\tmpSignal")
                OutputStream.Write(buffer, 0, buffer.Length)
                OutputStream.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("An error occured" & vbLf + ex.Message, "Error")
        Finally
            If Not cmd Is Nothing Then
                cmd.Dispose()
            End If
        End Try
        Return FileExists
    End Function
    Private Function LoadAnhNguoiDung(ByVal UName As String) As [Boolean]
        Dim FileExists As Boolean = False
        Dim cmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Try
            cmd.CommandText = "SELECT Picture FROM SYSUSER WHERE Uname='" + UName + "'"
            Dim buffer As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            If buffer.Length > 0 Then
                FileExists = True
                Dim OutputStream As Stream = File.OpenWrite(Application.StartupPath + "\tmpPicture")
                OutputStream.Write(buffer, 0, buffer.Length)
                OutputStream.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("An error occured" & vbLf + ex.Message, "Error")
        Finally
            If Not cmd Is Nothing Then
                cmd.Dispose()
            End If
        End Try
        Return FileExists
    End Function
    Private Sub SaveSignal(ByVal Uname As String)

        Dim cmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim trn As System.Data.SqlClient.SqlTransaction = Cn.BeginTransaction()
        cmd.Transaction = trn
        Try
            If picChuKy.Tag.ToString() = "" Then
                'Xoa chu ky hien tai
                cmd.CommandText = "UPDATE SYSUSER SET Signal=null WHERE UName='" + Uname + "'"
                cmd.ExecuteNonQuery()
            ElseIf picChuKy.Tag.ToString() <> "1" Then
                '? Co chon file anh khac
                Dim FileSize As Long = 0
                ' inputStream.Length;                   
                'picChuKy.Image.
                Dim inputStream As Stream = File.OpenRead(picChuKy.Tag.ToString())
                FileSize = inputStream.Length
                Dim data As Byte() = New [Byte](FileSize - 1) {}

                inputStream.Read(data, 0, CInt(FileSize))
                inputStream.Close()

                cmd.CommandText = "UPDATE SYSUSER SET Signal=@FileData WHERE UName='" + Uname + "'"
                cmd.Parameters.AddWithValue("@FileData", data)
                cmd.ExecuteNonQuery()
            End If
            If picAnhNguoiDung.Tag.ToString() = "" Then
                'Xoa anh hien tai
                cmd.CommandText = "UPDATE SYSUSER SET Picture=null WHERE UName='" + Uname + "'"
                cmd.ExecuteNonQuery()
            ElseIf picAnhNguoiDung.Tag.ToString() <> "1" Then
                '? Co chon file anh khac
                Dim FileSize As Long = 0
                ' inputStream.Length;                   
                'picChuKy.Image.
                Dim inputStream As Stream = File.OpenRead(picAnhNguoiDung.Tag.ToString())
                FileSize = inputStream.Length
                Dim data As Byte() = New [Byte](FileSize - 1) {}

                inputStream.Read(data, 0, CInt(FileSize))
                inputStream.Close()

                cmd.CommandText = "UPDATE SYSUSER SET Picture=@FileData WHERE UName='" + Uname + "'"
                cmd.Parameters.AddWithValue("@FileData", data)
                cmd.ExecuteNonQuery()
            End If
            trn.Commit()
        Catch ex As Exception
            trn.Rollback()

            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            cmd.Dispose()
            trn.Dispose()
        End Try
    End Sub

    Private Sub openFileDialog1_FileOk(ByVal sender As Object, ByVal e As CancelEventArgs) Handles openFileDialog1.FileOk
        Try
            'picChuKy.Load(openFileDialog1.FileName);
            'picChuKy.Tag = openFileDialog1.FileName;
            tmpPic.Load(openFileDialog1.FileName)
            tmpPic.Tag = openFileDialog1.FileName
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub mnuChonAnh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuChonAnh.Click
        openFileDialog1.ShowDialog()
    End Sub

    Private Sub picAnhNguoiDung_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picAnhNguoiDung.MouseUp
        If e.Button = MouseButtons.Right Then
            tmpPic = DirectCast(sender, PictureBox)
        End If
    End Sub

    Private Sub mnuXoaAnh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuXoaAnh.Click
        tmpPic.Image = imageList1.Images(0)
        tmpPic.Tag = ""

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, fgUser, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, fgFunct, "vi", Cn)
    End Sub
End Class
