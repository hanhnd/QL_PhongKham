Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPhieuChiDinh_A4Ngoai
    Public MaPhieuCD As String
    Public KhoaThucHien As String
    Public CapCuu As Byte
    Public TenBN As String
    Public Tuoi As Integer
    Public Gioi As String
    Public DiaChi As String


    Private Sub rptPhieuChiDinh_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        'Me.PageSettings.Margins.Top = 0.7
        'Me.PageSettings.Margins.Left = 0.5
        'Me.PageSettings.Margins.Right = 0.4
        'Me.PageSettings.Margins.Bottom = 0.5
        Me.PageSettings.Margins.Top = 0.2 '0.7
        'Me.PageSettings.Margins.Left = 0.1
        'sửa lại để in theo khổ ngang A4
        Me.PageSettings.Margins.Left = 0.1 + 5.85
        Me.PageSettings.Margins.Right = 0
        Me.PageSettings.Margins.Bottom = 0.1 '0.5
        'Barcode1.Text = MaPhieuCD
        If CapCuu = 1 Then
            chkCapCuu.Checked = True
        Else
            chkThuong.Checked = True
        End If
        'lblKhoa.Text = "KHOA: " & KhoaThucHien.ToUpper()
        lblTenBN.Text = TenBN
        lblTuoi.Text = "Tuổi: " & Tuoi.ToString()
        lblGioi.Text = "Giới: " & Gioi
        lblDiaChi.Text = DiaChi '"Địa chỉ: " & DiaChi
        If InStr(lblDoituong.Text, "Quân") > 0 Then
            picQuan.Visible = True
        Else
            picQuan.Visible = False
        End If
        lblTenPK.Text = TenPK.ToUpper
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        STT.Text = Val(STT.Text) + 1
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Dim h As Single = Detail1.Height
        STT.Height = h
        TextBox1.Height = h
        TextBox2.Height = h
        TextBox3.Height = h
        'TextBox4.Height = h
        'TextBox5.Height = h
        TextBox6.Height = h
        TextBox10.Height = h
        TextBox11.Height = h
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)
        STT.Text = "0"
    End Sub


End Class
