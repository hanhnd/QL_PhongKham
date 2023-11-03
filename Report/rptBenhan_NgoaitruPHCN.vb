Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptBenhan_NgoaitruPHCN
    Public MaPhieuCD As String
    Public Doituong As String
    Public Makhambenh As String
    Public KhoaThucHien As String
    Public CapCuu As Byte
    Public TenBN As String
    Public Tuoi As Integer
    Public Gioi As String
    Public DiaChi As String
    Public SqlstrDT As String = ""

    Private Sub rptPhieuChiDinh_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Dim rptCD As New rptSubChidinh_PHCN
        rptCD.SQLSTR = SqlstrDT
        Me.SubReport1.Report = rptCD
        lblTenPK.Text = TenPK.ToUpper
        'Me.PageSettings.Margins.Top = 0.7
        'Me.PageSettings.Margins.Left = 0.5
        'Me.PageSettings.Margins.Right = 0.4
        'Me.PageSettings.Margins.Bottom = 0.5
    End Sub

    'Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
    '    STT.Text = Val(STT.Text) + 1
    'End Sub

    'Private Sub Detail1_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
    '    Dim h As Single = Detail1.Height
    '    STT.Height = h
    '    TextBox1.Height = h
    '    TextBox2.Height = h
    '    TextBox3.Height = h
    '    TextBox4.Height = h
    '    TextBox5.Height = h
    '    TextBox6.Height = h
    'End Sub

      
End Class
