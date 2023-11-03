Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptSubChidinh_PHCN
    Public SQLSTR As String
    Dim TT
    Private Sub rptDonthuoc_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Dim ds = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        ds.ConnectionString = ConnectionStr ' + "Password="
        ds.SQL = SQLSTR
        Me.DataSource = ds
        TT = 0
        'dr = SQLCmd.ExecuteReader()
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        'txtTT.Height = Me.Detail1.Height
        'TextBox2.Height = Me.Detail1.Height
        'TextBox3.Height = Me.Detail1.Height
        'TextBox4.Height = Me.Detail1.Height
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        TT = TT + 1
        txtTT.Text = "  " + Trim(Str(TT))
    End Sub
End Class
