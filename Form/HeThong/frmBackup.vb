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
Public Class frmBackup
    Private Sub cmdChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien.Click
        Dim SqlStr As String
        Dim Cmd As SqlCommand
        Dim BKFileName As String
        Try
            BKFileName = lblTenFile.Text
            SqlStr = "BACKUP DATABASE QUANSO_QL" _
                            & " TO DISK = '" & BKFileName & "' WITH INIT," _
                            & "RETAINDAYS= 7"
            Cmd = New SqlCommand(SqlStr, Cn)
            Cmd.ExecuteNonQuery()
            MsgBox("Thực hiện xong !", vbInformation, "Sao lưu dữ liệu")
            Exit Sub
        Catch ex As Exception
            MsgBox("Có lỗi: " + ex.Message + " khi sao lưu dữ liệu", MsgBoxStyle.Critical, "Message !")
            MsgBox("Hãy khởi động lại phần mềm ", MsgBoxStyle.Information, "Message !")
        End Try
    End Sub
    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Hide()
    End Sub

    Private Sub cmdChonFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChonFile.Click
        With SaveFileDialog1
            .Title = "Nhập file sao lưu"
            .ShowDialog()
            lblTenFile.Text = .FileName
        End With
    End Sub

    Private Sub frmBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lblTenFile.Text = Application.StartupPath + "\BKData_" + MaDonVi_Main + "_" + Format(GetSrvDate, "yyMM") + ".back"
    End Sub
End Class

 
 


