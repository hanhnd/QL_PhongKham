Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPhieuthu_A5
    Public SqlStr As String
    Dim STT As Integer
    Private Sub rptPhieuthu_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        'Me.PageSettings.DefaultPaperSize = True
        'PageSettings.Margins.Top = 0.01F
        'PageSettings.Margins.Left = 0.01F
        'PageSettings.Margins.Right = 0.01F
        'PageSettings.Margins.Bottom = 0.01F

        Me.PageSettings.Margins.Top = 0.2 '0.7
        'Me.PageSettings.Margins.Left = 0.1
        'sửa lại để in theo khổ ngang A4
        Me.PageSettings.Margins.Left = 0.1 + 5.85
        Me.PageSettings.Margins.Right = 0
        Me.PageSettings.Margins.Bottom = 0.1
        'lblTenPK.Text = GetSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", "")
        Dim ds = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        ds.ConnectionString = ConnectionStr
        ds.SQL = SqlStr
        Me.DataSource = ds
        STT = 0
        'lblTenPK.Text = TenPK.ToUpper
        'lblTenPK.Text.ToUpper()
        'lblDiachiPK.Text = DiachiPK
        Label4.Text = TenPK.ToUpper
        Label5.Text = "Ad:" + DiachiPK
        Label13.Text = "Hotline: " + SoDienThoaiPK + " - Email: " + EmailPK
        mdlFunction.Set_Text_Report(Me, "rptPhieuthu", Lang)
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Dim h As Decimal = Me.Detail1.Height
        For Each txt As ARControl In Detail1.Controls
            txt.Height = Detail1.Height
        Next
    End Sub

    Private Sub ReportFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.BeforePrint
        txtTienphaitra.Text = Format(Val(txtSotien_So.Text.Replace(" ", "")) - Val(txtTongMiengiam.Text.Replace(" ", "")), "### ### ###")
        txtSotien_Chu.Text = ReadMoney(txtSotien_So.Text.Replace(" ", "")) + " đồng."
        txtNguoilapphieu.Text = Tendaydu
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        STT = STT + 1
        txtSTT.Text = STT.ToString.Trim

    End Sub
End Class
