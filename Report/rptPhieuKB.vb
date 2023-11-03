Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPhieuKB

    Private Sub rptPhieuKB_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        lblTenPK.Text = TenPK.ToUpper
        'lblTenPK.Text.ToUpper()
    End Sub
End Class
