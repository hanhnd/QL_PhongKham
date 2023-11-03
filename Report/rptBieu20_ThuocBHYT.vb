Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptBieu20_ThuocBHYT
    Public NgaythuphiKB As Date
    Public SQl As String
    Dim tt As Integer
    Dim Tongtien As Double
    Dim Tongtien_Thua As Double
    Dim Tongtien_Thieu As Double
    Private Sub rptPhiKB_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Dim ds = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        ds.ConnectionString = Cn.ConnectionString
        ds.SQL = SQl
        Me.DataSource = ds
        lblTenPK.Text = TenPK
        lblMaDKKCBBD.Text = "Mã số: " + MaDKKCBBD
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Dim h = Me.Detail1.Height
        txtTT.Height = h
        TextBox1.Height = h
        TextBox2.Height = h
        TextBox3.Height = h
        TextBox4.Height = h
        TextBox5.Height = h
        TextBox6.Height = h
        TextBox9.Height = h
        TextBox10.Height = h
        TextBox11.Height = h
        TextBox12.Height = h
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        TextBox10.Text = Format(Val(TextBox10.Text), "### ### ###")
        TextBox6.Text = Format(Val(TextBox6.Text), "### ### ###")
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        'txtTongtien.Text = Format(Tongtien, "### ### ###") + " đồng"
        'txtBangchu.Text = ReadMoney(Trim(Str(Tongtien))) + " đồng"
        'Label20.Text = Format(Tongtien_Thua, "### ### ###")
        'Label21.Text = Format(Tongtien_Thieu, "### ### ###")
    End Sub
End Class
