Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPhieuthu_InNhiet
    Public SqlStr As String
    Dim STT As Integer
    Private Sub rptPhieuthu_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.PageSettings.DefaultPaperSize = True
        PageSettings.Margins.Top = 0.01F
        PageSettings.Margins.Left = 0.01F
        PageSettings.Margins.Right = 0.01F
        PageSettings.Margins.Bottom = 0.01F

        Dim ds = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        ds.ConnectionString = ConnectionStr
        ds.SQL = SqlStr
        Me.DataSource = ds
        STT = 0
        'lblTenPK.Text = TenPK.ToUpper
        'lblDiachiPK.Text = DiachiPK
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Dim h As Decimal = Me.Detail1.Height
        For Each txt As ARControl In Detail1.Controls
            txt.Height = Detail1.Height
        Next
    End Sub

    Private Sub ReportFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.BeforePrint
        txtTienphaitra.Text = Format(Val(txtSotien_So.Text.Replace(" ", "")) - Val(txtTongMiengiam.Text.Replace(" ", "")), "### ### ###")
        txtSotien_Chu.Text = ReadMoney(txtTienphaitra.Text.Replace(" ", "")) + " đồng."
        lblNguoithu.Text = Tendaydu
    End Sub
 
    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        STT = STT + 1
        txtSTT.Text = STT.ToString.Trim
    End Sub
End Class
