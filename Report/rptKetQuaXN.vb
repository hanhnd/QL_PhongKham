Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptKetQuaXN
    Public MaPhieuCD As String
    Public CapCuu As Byte
    Public SQl As String
    Dim tt As Integer
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
        lblTenPK.Text = TenPK.ToUpper()
        'GetSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", "")
        'Barcode1.Text = MaPhieuCD
        If CapCuu = 1 Then
            chkCapCuu.Checked = True
        Else
            chkThuong.Checked = True
        End If

        Dim _ds As DataDynamics.ActiveReports.DataSources.SqlDBDataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource()
        _ds.ConnectionString = ConnectionStr
        _ds.SQL = SQl
        Me.DataSource = _ds
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        STT.Text = Val(STT.Text) + 1
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Dim h As Decimal = Me.Detail1.Height
        For Each txt As ARControl In Detail1.Controls
            txt.Height = Detail1.Height
        Next
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)
        STT.Text = "0"
    End Sub
End Class
