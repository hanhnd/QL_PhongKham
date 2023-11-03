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

Public Class frmMauKQ_CDHA
    Const file_mau = "D:\Mau_KQ.docx"
    Const file_save = "D:\Mau_KQ_saved.docx"
    Private Sub Load_DSMau(ByVal TenBS As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Try
            grdDS.Rows.Count = 0
            grdDS.Redraw = False
            SQL = "Select * from DMCDHA_MAUKQ  order by Khuvuc,nhom, tenmau "
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            Do While Dr.Read()
                grdDS.AddItem(Dr!Khuvuc.ToString & vbTab & Dr!nhom & vbTab & Dr!tenmau)
            Loop
            Dr.Close()
            grdDS.Tree.Column = 2
            grdDS.Cols(0).Visible = False
            grdDS.Cols(1).Visible = False
            'grdDS.Subtotal(AggregateEnum.None, 0, 1, "{0}")
            grdDS.Subtotal(AggregateEnum.None, 0, 0, 2, "{0}")
            grdDS.Subtotal(AggregateEnum.None, 1, 1, 2, "{0}")

            grdDS.AutoSizeCols()
            grdDS.Redraw = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Load_DSNhom(ByVal TenBS As String, ByVal Khuvuc As String)
        Dim SQLStr As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim DsDM As DataSet
        Try
            SQLStr = "Select distinct Nhom from DMCDHA_MAUKQ where  Khuvuc = N'" & Khuvuc & "' order by nhom "
            Cmd = New SqlCommand(SQLStr, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            DsDM = New DataSet
            Adap.Fill(DsDM, "DMNHOM")
            Cmd.Dispose()

            cmbNhom.ColumnWidth = 500
            cmbNhom.DataSource = DsDM.Tables("DMNHOM")
            cmbNhom.DisplayMember = "Nhom"
            cmbNhom.ValueMember = "Nhom"
            cmbNhom.Text = ""
            cmbNhom.AutoDropDown = True

            Adap.Dispose()
            DsDM.Dispose()
            Adap = Nothing
            Cmd = Nothing
            DsDM = Nothing
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Load_DSKhuvuc(ByVal TenBS As String)
        Dim SQLStr As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim DsDM As DataSet
        Try
            SQLStr = "Select distinct Khuvuc from DMCDHA_MAUKQ  order by Khuvuc "
            Cmd = New SqlCommand(SQLStr, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            DsDM = New DataSet
            Adap.Fill(DsDM, "DMKHUVUC")
            Cmd.Dispose()

            cmbKhuvuc.ColumnWidth = 500
            cmbKhuvuc.DataSource = DsDM.Tables("DMKHUVUC")
            cmbKhuvuc.DisplayMember = "Khuvuc"
            cmbKhuvuc.ValueMember = "Khuvuc"
            cmbKhuvuc.Text = ""
            cmbKhuvuc.AutoDropDown = True

            Adap.Dispose()
            DsDM.Dispose()
            Adap = Nothing
            Cmd = Nothing
            DsDM = Nothing
        Catch ex As Exception
        End Try
        
    End Sub

    Private Sub Lock_Control(ByVal DK As Boolean)
        cmdGhi.Visible = DK
        cmdKhongghi.Visible = DK
        grdDS.Enabled = Not DK

        cmdThem.Visible = Not DK
        cmdSua.Visible = Not DK
        cmdXoa.Visible = Not DK
        cmdThoat.Visible = Not DK
    End Sub
    Private Sub SetEmpty()
        'cmbNhom.Text = ""
        'cmbNhom.SelectedValue = ""
        txtTen.Text = ""
        txtTen.Focus()
        'Load_DSKhuvuc(Tendangnhap)
        cmbKhuvuc.Enabled = True
        cmbNhom.Enabled = True
        txtTen.Enabled = True
    End Sub
    Private Sub Fill_Mau(ByVal BS As String, ByVal Khuvuc As String, ByVal Nhom As String, ByVal Ten As String)
        Dim Temp As Byte()
        Try
            Cmd = New SqlCommand("", Cn)
            Cmd.CommandText = String.Format("SELECT Khuvuc, Nhom, Tenmau, isnull(FileData,'') as FileData FROM DMCDHA_MAUKQ WHERE  Nhom = {2} and Tenmau = {3}  and Khuvuc = {1} ", "N'" + BS.Replace("'", "''") + "'", "N'" + Nhom.Replace("'", "''") + "'", "N'" + Ten.Replace("'", "''") + "'", "N'" + Khuvuc.Replace("'", "''") + "'")
           
            dr = Cmd.ExecuteReader()
            While dr.Read()
                cmbKhuvuc.Text = dr("Khuvuc").ToString
                cmbNhom.Text = dr("Nhom").ToString
                txtTen.Text = dr("Tenmau")
                Temp = dr("FileData")
            End While
           
            Dim memoryStream As New MemoryStream(Temp)
            RichEditControl1.LoadDocument(memoryStream, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            dr.Close()

           
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
            dr.Close()
        End Try
    End Sub
    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        
        Me.Dispose()
    End Sub

    Private Sub cmdChonfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChonfile.Click
        Dim filNm As String
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = "MS-Word Files (*.doc,*.dot,*.docx) | *.doc;*.dot;*.docx"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            filNm = OpenFileDialog1.FileName
        Else
            Return
        End If
        'MessageBox.Show("Please wait while the document is being displayed")
        'Try
        '    objWinWordControl.CloseControl()
        'Catch ex1 As Exception
        '    objWinWordControl.document = null
        '    WinWordControl.WinWordControl.wd = null
        '    WinWordControl.WinWordControl.wordWnd = 0
        'End Try

        Try
            'Load the template used for testing.
            'objWinWordControl.LoadDocument(filNm)
            RichEditControl1.LoadDocument(filNm)
        Catch ex2 As Exception
            MsgBox(ex2.Message)
        End Try

        'btnClientName.Enabled = True
        'btnRecNo.Enabled = True
        'btnCurrentDate.Enabled = True
    End Sub

    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        'If System.IO.File.Exists(file_save) Then System.IO.File.Delete(file_save)
        
        If cmbKhuvuc.Text.Trim = "" Or cmbNhom.Text.Trim = "" Or txtTen.Text.Trim = "" Then
            MsgBox("Phải nhập đủ: Khu vực, Nhóm, Tên mẫu")
            Exit Sub
        End If
        Save_mau(Tendangnhap, cmbKhuvuc.Text, cmbNhom.Text, txtTen.Text)
        Load_DSMau(Tendangnhap)
        Lock_Control(False)
       
    End Sub
    Private Sub Save_mau(ByVal BS As String, ByVal khuvuc As String, ByVal nhom As String, ByVal ten As String)
       
        Dim FileID As String = "0"
      
        If System.IO.File.Exists(file_save) Then System.IO.File.Delete(file_save)
        Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        cmd.Connection = Cn
        'Xóa mẫu cũ Nguoidung ={0} 
        cmd.CommandText = String.Format("DELETE FROM DMCDHA_MAUKQ WHERE Nhom = {1} and Tenmau = {2} and Khuvuc = {3} ", "N'" + BS.Replace("'", "''") + "'", "N'" + nhom.Replace("'", "''") + "'", "N'" + ten.Replace("'", "''") + "'", "N'" + khuvuc.Replace("'", "''") + "'")
        cmd.ExecuteNonQuery()
        ' Thêm mẫu mới
        cmd.CommandText = "INSERT INTO DMCDHA_MAUKQ (Nguoidung,Nhom,Tenmau,FileData, Khuvuc) VALUES (@Nguoidung,@Nhom,@Tenmau,@FileData, @Khuvuc)"
        cmd.Parameters.AddWithValue("@Nguoidung", BS)
        cmd.Parameters.AddWithValue("@Nhom", nhom)
        cmd.Parameters.AddWithValue("@Tenmau", ten)
        cmd.Parameters.AddWithValue("@FileData", RichEditControl1.OpenXmlBytes())
        cmd.Parameters.AddWithValue("@Khuvuc", khuvuc)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        MessageBox.Show("Đã cập nhật mẫu kết quả")
    End Sub
    'protected override sub Dispose( bool disposing )
    '		{
    '			if( disposing )
    '			{
    '				if (components != null) 
    '				{
    '					components.Dispose();
    '				}
    '			}
    '			base.Dispose( disposing );
    '		}
      
    Private Sub frmMauKQ_CDHA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_DSMau(Tendangnhap)
        Load_DSKhuvuc(Tendangnhap)
        cmbKhuvuc.ClearItems()
        cmbKhuvuc.AddItem("XQ")
        cmbKhuvuc.AddItem("XS")
        cmbKhuvuc.AddItem("CT")
        cmbKhuvuc.AddItem("SA")
        cmbKhuvuc.AddItem("MR")
        cmbKhuvuc.AddItem("DT")
        cmbKhuvuc.AddItem("DN")
        cmbKhuvuc.AddItem("GP")
    End Sub

    Private Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        Lock_Control(True)
        SetEmpty()
    End Sub

    Private Sub cmdKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKhongghi.Click
        Lock_Control(False)
    End Sub

    Private Sub cmdXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoa.Click
        Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        cmd.Connection = Cn
        If MsgBox("Bạn có chắc chắn muốn xóa mẫu: " + txtTen.Text + " không?", MsgBoxStyle.YesNo, "Cảnh báo!") = MsgBoxResult.No Then Exit Sub
        cmd.CommandText = String.Format("DELETE FROM DMCDHA_MAUKQ WHERE Nhom = {1} and Tenmau = {2}  and Khuvuc = {3} ", "N'" + TenDangNhap.Replace("'", "''") + "'", "N'" + cmbNhom.Text.Replace("'", "''") + "'", "N'" + txtTen.Text.Replace("'", "''") + "'", "N'" + cmbKhuvuc.Text.Replace("'", "''") + "'")
        cmd.ExecuteNonQuery()

        Load_DSMau(Tendangnhap)
        Load_DSKhuvuc(Tendangnhap)
    End Sub

    Private Sub cmdSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSua.Click
        Lock_Control(True)
        cmbNhom.Enabled = False
        txtTen.Enabled = False
    End Sub
    Private Sub LoadFile(ByVal buffer As Byte())
        'Try
        '    If (buffer.Length > 0) Then
        '        Dim OutputStream As Stream = File.OpenWrite(file_mau)
        '        OutputStream.Write(buffer, 0, buffer.Length)
        '        OutputStream.Close()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("An error occured\n" + ex.Message, "Error")
        'End Try
    End Sub

    Private Sub grdDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDS.Click
        If grdDS.Item(grdDS.Row, 0) = Nothing Then Exit Sub
        'For Each prc As Process In Process.GetProcessesByName("WINWORD")
        '    prc.Kill()
        'Next
        Fill_Mau(Tendangnhap, grdDS.Item(grdDS.Row, 2), grdDS.Item(grdDS.Row, 0), grdDS.Item(grdDS.Row, 1))
    End Sub

    Private Sub cmbKhuvuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKhuvuc.TextChanged
        Load_DSNhom(Tendangnhap, cmbKhuvuc.Text)
    End Sub
End Class