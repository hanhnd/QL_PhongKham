Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPhieuthu 
 
    Private Sub rptPhieuthu_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.PageSettings.PaperKind = Printing.PaperKind.A4
        Me.PageSettings.Orientation = PageOrientation.Landscape
        Me.PageSettings.Margins.Left = 5.9

        txtYeucaukham.Border.Style = BorderLineStyle.Solid
        txtYeucaukham.Border.TopColor = Color.Black
        txtYeucaukham.Border.LeftColor = Color.Black
        txtYeucaukham.Border.BottomColor = Color.Black

        TextBox2.Border.Style = BorderLineStyle.Solid
        TextBox2.Border.TopColor = Color.Black
        TextBox2.Border.BottomColor = Color.Black
        TextBox2.Border.RightColor = Color.Black

        Label19.Border.Style = BorderLineStyle.Solid
        Label19.Border.RightColor = Color.Black
        Label19.Border.TopColor = Color.Black
        Label19.Border.LeftColor = Color.Black
        Label19.Border.BottomColor = Color.Black
        Label19.Border.RightColor = Color.Black

        Label22.Border.Style = BorderLineStyle.Solid
        Label22.Border.RightColor = Color.Black
        Label22.Border.TopColor = Color.Black
        Label22.Border.LeftColor = Color.Black
        Label22.Border.BottomColor = Color.Black
        Label22.Border.RightColor = Color.Black

        Label23.Border.Style = BorderLineStyle.Solid
        Label23.Border.RightColor = Color.Black
        Label23.Border.TopColor = Color.Black
        Label23.Border.LeftColor = Color.Black
        Label23.Border.BottomColor = Color.Black
        Label23.Border.RightColor = Color.Black

        Label6.Border.Style = BorderLineStyle.Solid
        Label6.Border.RightColor = Color.Black
        Label6.Border.TopColor = Color.Black
        Label6.Border.LeftColor = Color.Black
        Label6.Border.BottomColor = Color.Black
        Label6.Border.RightColor = Color.Black

        txtSotien_So.Border.Style = BorderLineStyle.Solid
        txtSotien_So.Border.RightColor = Color.Black
        txtSotien_So.Border.TopColor = Color.Black
        txtSotien_So.Border.LeftColor = Color.Black
        txtSotien_So.Border.BottomColor = Color.Black
        txtSotien_So.Border.RightColor = Color.Black
        lblTenPK.Text = TenPK.ToUpper
        'lblTenPK.Text.ToUpper()
        lblDiachiPK.Text = DiachiPK
    End Sub
End Class
