Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptBieu21_DichvuBHYT
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
        TextBox2.Height = h
        TextBox6.Height = h
        TextBox10.Height = h
        TextBox11.Height = h
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        TextBox10.Text = Format(Val(TextBox10.Text), "### ### ###")
        TextBox6.Text = Format(Val(TextBox6.Text), "### ### ###")
        If txtTT.Text = "" Then
            TextBox2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            TextBox6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Else
            TextBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            TextBox6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        'txtTongtien.Text = Format(Tongtien, "### ### ###") + " đồng"
        'txtBangchu.Text = ReadMoney(Trim(Str(Tongtien))) + " đồng"
        'Label20.Text = Format(Tongtien_Thua, "### ### ###")
        'Label21.Text = Format(Tongtien_Thieu, "### ### ###")
    End Sub
End Class
