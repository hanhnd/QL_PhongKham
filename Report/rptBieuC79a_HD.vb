Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptBieuC79a_HD
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
        TextBox10.Height = h
        TextBox6.Height = h
        TextBox9.Height = h
        TextBox11.Height = h
        TextBox13.Height = h
        TextBox14.Height = h
        TextBox15.Height = h
        TextBox16.Height = h
        TextBox17.Height = h
        TextBox18.Height = h
        TextBox19.Height = h
        TextBox20.Height = h
        TextBox21.Height = h
        TextBox22.Height = h
        TextBox24.Height = h
        TextBox25.Height = h
        TextBox26.Height = h
        TextBox27.Height = h
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        tt += 1
        txtTT.Text = tt.ToString.Trim
        TextBox42.Text = (Val(TextBox42.Text) + Val(TextBox6.Text)).ToString
        TextBox57.Text = (Val(TextBox57.Text) + Val(TextBox13.Text)).ToString
        TextBox43.Text = (Val(TextBox43.Text) + Val(TextBox14.Text)).ToString
        TextBox44.Text = (Val(TextBox44.Text) + Val(TextBox15.Text)).ToString
        TextBox45.Text = (Val(TextBox45.Text) + Val(TextBox16.Text)).ToString
        TextBox46.Text = (Val(TextBox46.Text) + Val(TextBox17.Text)).ToString
        TextBox47.Text = (Val(TextBox47.Text) + Val(TextBox18.Text)).ToString
        TextBox48.Text = (Val(TextBox48.Text) + Val(TextBox19.Text)).ToString
        TextBox49.Text = (Val(TextBox49.Text) + Val(TextBox20.Text)).ToString
        TextBox50.Text = (Val(TextBox50.Text) + Val(TextBox21.Text)).ToString
        TextBox51.Text = (Val(TextBox51.Text) + Val(TextBox22.Text)).ToString
        TextBox52.Text = (Val(TextBox52.Text) + Val(TextBox24.Text)).ToString
        TextBox53.Text = (Val(TextBox53.Text) + Val(TextBox25.Text)).ToString
        TextBox54.Text = (Val(TextBox54.Text) + Val(TextBox26.Text)).ToString
        TextBox55.Text = (Val(TextBox55.Text) + Val(TextBox27.Text)).ToString


        TextBox6.Text = Format(Val(TextBox6.Text), "### ### ###")
        TextBox13.Text = Format(Val(TextBox13.Text), "### ### ###")
        TextBox14.Text = Format(Val(TextBox14.Text), "### ### ###")
        TextBox15.Text = Format(Val(TextBox15.Text), "### ### ###")
        TextBox16.Text = Format(Val(TextBox16.Text), "### ### ###")
        TextBox17.Text = Format(Val(TextBox17.Text), "### ### ###")
        TextBox18.Text = Format(Val(TextBox18.Text), "### ### ###")
        TextBox19.Text = Format(Val(TextBox19.Text), "### ### ###")
        TextBox20.Text = Format(Val(TextBox20.Text), "### ### ###")
        TextBox21.Text = Format(Val(TextBox21.Text), "### ### ###")
        TextBox22.Text = Format(Val(TextBox22.Text), "### ### ###")
        TextBox24.Text = Format(Val(TextBox24.Text), "### ### ###")
        TextBox25.Text = Format(Val(TextBox25.Text), "### ### ###")
        TextBox26.Text = Format(Val(TextBox26.Text), "### ### ###")
        TextBox27.Text = Format(Val(TextBox27.Text), "### ### ###")
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        tt = 0
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        txtBangchu.Text = ReadMoney(TextBox55.Text.Trim) + " đồng"
    End Sub
End Class
