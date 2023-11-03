Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptPhieuKB_Innhiet

    Private Sub rptPhieuKB_Innhiet_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.PageSettings.DefaultPaperSize = True
        PageSettings.Margins.Top = 0.01F
        PageSettings.Margins.Left = 0.01F
        PageSettings.Margins.Right = 0.01F
        PageSettings.Margins.Bottom = 0.01F
        txtTenbenhnhan.Border.BottomStyle = BorderLineStyle.None
        txtNamsinh.Border.BottomStyle = BorderLineStyle.None
        txtGioitinh.Border.BottomStyle = BorderLineStyle.None
        TextBox1.Border.BottomStyle = BorderLineStyle.None
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
