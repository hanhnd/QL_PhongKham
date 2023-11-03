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
Public Class frmChange_Pass

    Private Sub cmdThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThuchien.Click
        Try
            If txtOld_Pass.Text <> MatKhau Then
                MsgBox("Did not enter the old password correctly.", vbCritical, "Message!")
                txtOld_Pass.Focus()
                Exit Sub
            End If
            If txtNew_Pass.Text <> txtConf_Newpass.Text Then
                MsgBox("Confirmed new password is not correct.", vbCritical, "Message!")
                txtConf_Newpass.Focus()
                Exit Sub
            Else
                Dim InsertCmd As SqlCommand = New SqlCommand("", Cn)
                InsertCmd.CommandText = "UPDATE " + Sys_DB + ".dbo.SYSUSER set Pass = '" + getMd5Hash(txtNew_Pass.Text) + "' WHERE UName ='" + TenDangNhap + "'"
                InsertCmd.ExecuteNonQuery()
                InsertCmd.Dispose()
                MsgBox("Password has been changed.", MsgBoxStyle.Information, "Message!")
                Me.Dispose()
            End If
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub frmChange_Pass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlFunction.Set_Text(Me, Lang)
    End Sub
End Class


