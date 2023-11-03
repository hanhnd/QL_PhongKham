Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptDonthuocSua
    Public SQLSTR As String
    Dim TT
    Private Sub rptDonthuoc_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Dim ds = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        ds.ConnectionString = ConnectionStr
        ds.SQL = SQLSTR
        Me.DataSource = ds
        TT = 0
      
        'sửa lại để in theo khổ ngang A4
        Me.PageSettings.Margins.Left = 0.1 + 5.85
        ''Label4.Text = Label4.Text.ToUpper() ''GetSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", "")
        Label2.Text = TenPK.ToUpper
        Label11.Text = "Ad:" + DiachiPK
        Label17.Text = "Hotline: " + SoDienThoaiPK + " - Email: " + EmailPK
        mdlFunction.Set_Text_Report(Me, "rptDonthuoc", Lang)
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        'txtTT.Height = Me.Detail1.Height
        'TextBox2.Height = Me.Detail1.Height
        'TextBox3.Height = Me.Detail1.Height
        'TextBox4.Height = Me.Detail1.Height
        'TextBox5.Height = Me.Detail1.Height

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        TT = TT + 1
        txtTT.Text = Trim(Str(TT)) + "."
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        'txtCongkhoan.Text = TT.ToString.Trim + " khoản"
        'lblBacsi.Text = Tendaydu
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format

    End Sub
End Class
