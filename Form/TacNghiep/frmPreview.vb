Public Class frmPreview
    Public Goi As String
    Public NgaythuphiKB As Date  ' cho bao cao: "Bang thu tien kham benh ngoai tru"
    Public Mabenhnhan, Tenbenhnhan, Doituong, Namsinh, Gioitinh, Diachi, Yaucaukham, Buongso, TT, Ngaykham As String
    Public ThuocMua_Cap, Ketluanbenh, Mabenh, Loidan, Ngaydonthuoc, lblDIachi_Capbac, SQL_str
    Public Bacsy, taikham As String
    'Dim rptPKB As New rptPhieuKB
    'Dim rptPhikham As New rptPhiKB
    Public rptDT As New rptDonthuocSua

    Public Sub arViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles arViewer.Load
        Select Case Goi
           
            Case "Don thuoc"
                rptDT.SQLSTR = SQL_str
                rptDT.txtTenbenhnhan.Text = Tenbenhnhan
                rptDT.txtNamsinh.Text = Namsinh
                rptDT.txtGioitinh.Text = Gioitinh

                rptDT.txtDiachi.Text = Diachi
                rptDT.lblDIachi_Capbac.Text = lblDIachi_Capbac
                rptDT.txtChandoan.Text = Ketluanbenh
                rptDT.TextBox5.Text = Mabenh
                rptDT.txtLoidan.Text = Loidan
                'rptDT.lblNguoibenh.Text = Tenbenhnhan
                rptDT.lblBacsi.Text = Bacsy
                rptDT.lblTaiKham.Text = rptDT.lblTaiKham.Text + taikham
                rptDT.txtNgaythang.Text = Ngaydonthuoc
                Me.arViewer.Document = rptDT.Document
                'rptDT.Run(True)
                rptDT.Show()
        End Select
    End Sub

    Private Sub arViewer_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles arViewer.MouseWheel

    End Sub

    Private Sub arViewer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles arViewer.Validated

    End Sub
End Class