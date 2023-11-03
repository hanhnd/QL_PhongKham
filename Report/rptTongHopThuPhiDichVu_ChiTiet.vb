Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptTongHopThuPhiDichVu_ChiTiet
    Public TuNgay As DateTime
    Public DenNgay As DateTime
    Dim tt As Integer
    Dim stt As Integer
    Public SQl As String

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        stt = 0
        tt = tt + 1
        txtTT.Text = "(" + Trim(Str(tt)) + ")"
    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        stt = stt + 1
        txtSoTT.Text = Trim(Str(stt)) + ". "
    End Sub

    Private Sub GroupHeader1_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.BeforePrint

    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint

    End Sub

    Private Sub rptTongHopThuPhiDichVu_ChiTiet_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        tt = 0
        Dim ds As DataDynamics.ActiveReports.DataSources.SqlDBDataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource()
        ds.ConnectionString = ConnectionStr
        ds.SQL = SQl
        Me.DataSource = ds
        lblTenPK.Text = TenPK.ToUpper
        'GetSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", "")
        ''txtNgaythang.Text = "Từ " + Format(TuNgay, "dd/MM/yyyy HH:mm") + " đến " + Format(DenNgay, "dd/MM/yyyy HH:mm")
    End Sub
End Class
