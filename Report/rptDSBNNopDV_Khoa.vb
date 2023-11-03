Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptDSBNNopDV_Khoa
    Public NgaythuphiKB As Date
    Public SQl As String
    Dim tt As Integer
    Dim Tongtien As Double
    Private Sub rptPhiKB_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Dim ds = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        ds.ConnectionString = ConnectionStr
        ds.SQL = SQl
        Me.DataSource = ds
        tt = 0
        Tongtien = 0
        Me.Label5.Text = "Ngày " + Format(Ngayhientai, "dd") + " tháng " + Format(Ngayhientai, "MM") + " năm " + Format(Ngayhientai, "yyyy")
        Me.Label6.Text = Tendaydu
        Me.lblTenPK.Text = TenPK
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        tt = tt + 1
        txtTT.Text = Trim(Str(tt))
        Tongtien = Tongtien + Val(TextBox6.Text)
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        txtTongtien.Text = Format(Tongtien, "### ### ###") + " đồng"
        txtBangchu.Text = ReadMoney(Trim(Str(Tongtien))) + " đồng"
    End Sub
End Class
