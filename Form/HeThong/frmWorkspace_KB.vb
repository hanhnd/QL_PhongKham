Imports System.Data
Imports System.Data.SqlClient
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
Public Class frmWorkspace_KB

    Private Sub frmWorkspace_KB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        fgLichCongtac.ClipSeparators = "|;"
        fgThongBao.ClipSeparators = "|;"
        Lich.SetDate(GetSrvDate)
        'MessageBox.Show(Lich.SelectionRange.End.Date.ToString());
        LayNgayGio()
        fgThongBao.Item(1, 0) = tb11
        fgThongBao.Item(1, 1) = tb21
        fgThongBao.Item(1, 2) = tb31
        fgThongBao.Item(2, 0) = tb12
        fgThongBao.Item(2, 1) = tb22
        fgThongBao.Item(2, 2) = tb32
    End Sub
    Private Sub LayNgayGio()
        Try
            Dim Thoigian As Date
            Thoigian = GetSrvDate()
            lblNgay.Text = String.Format("{0:dd - MM - yyyy}", Thoigian)
            lblGio.Text = String.Format("{0:hh:mm}", Thoigian)
            ''    Load_DuLieu(Lich.SelectionRange.End.Date)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer1.Tick
        LayNgayGio()
    End Sub
    Private Sub Load_DuLieu(ByVal Ngay As Object)
        'lblLichCongTac.Text = String.Format("Lịch công tác - Ngày: {0:dd/MM/yyyy}", Lich.SelectionRange.End.Date)
        'lblThongBao.Text = String.Format("Message - Ngày: {0:dd/MM/yyyy}", Lich.SelectionRange.End.Date)

        'Dim SQLCmd As New SqlCommand("", Cn)
        'Dim dr As SqlDataReader
        'SQLCmd.CommandText = String.Format("SELECT * FROM [SYSDB103].DBO.LICHCONGTAC WHERE (DATEDIFF(day, TuGio, '{0:MM/dd/yyyy}')>=0) AND (DATEDIFF(day, DenGio, '{0:MM/dd/yyyy}')<=0)", Ngay)
        'fgLichCongtac.Cols(0).AllowMerging = True  '//AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free 
        'Try
        '    {
        '        fgLichCongtac.Redraw = false;
        '        fgThongBao.Redraw = false;
        '        dr = SQLCmd.ExecuteReader();                
        '        fgLichCongtac.Rows.Count = 1;
        '    While (dr.Read())
        '        {
        '            fgLichCongtac.AddItem(string.Format("{0:dd/MM/yyyy HH:mm}|{1:dd/MM/yyyy HH:mm}|{2}|{3}|{4}",  dr["TuGio"], dr["DenGio"], dr["NoiDung"],dr["DiaDiem"],dr["HoTen"]));
        '        }                
        '        dr.Close();
        '        fgLichCongtac.AutoSizeCols(0, fgLichCongtac.Cols.Count - 1, 1);
        '        SQLCmd.CommandText = string.Format("SELECT * FROM [SYSDB103].DBO.THONGBAO WHERE DATEDIFF(day,GioGui, '{0:MM/dd/yyyy}')=0 AND (NguoiNhan Is Null OR NguoiNhan='{1}')", Ngay,Global.glbUName);
        '        dr = SQLCmd.ExecuteReader();
        '        fgThongBao.Rows.Count = 1;
        '        While (dr.Read())
        '        {
        '            fgThongBao.AddItem(string.Format("{0:dd/MM/yyyy HH:mm}|{1}|{2}|{3}", dr["GioGui"], dr["NguoiGui"], dr["NoiDung"], dr["SmsID"]));
        '        }
        '        dr.Close();
        '        int cuchuoi=15 - fgThongBao.Rows.Count;
        '        for (int i = 0; i <cuchuoi ; i++)
        '        {
        '            fgThongBao.AddItem("");
        '        }               
        '        fgThongBao.AutoSizeCols(0, fgLichCongtac.Cols.Count - 1, 1);
        '        fgLichCongtac.Redraw = true;
        '        fgThongBao.Redraw = true;
        '    }
        '    catch
        '    {
        '    }
        'Finally
        '    {
        '        SQLCmd.Dispose();
        '    }
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Dim directory As String = My.Application.Info.DirectoryPath
        System.Diagnostics.Process.Start(directory + "\\TEAMVIEWER.EXE")
    End Sub
End Class