Imports System.Data
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.Collections.Specialized
Public Class frmDS_SoTayChiDinh

    Private Sub frmDS_SoTayChiDinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim dr As System.Data.SqlClient.SqlDataReader
        SQLCmd.CommandText = "Select ID_SoCD,Mota from tblSOTAYCHIDINH WHERE Uname='" + TenDangNhap + "'"
        'Me.Text = "Sổ tay chỉ định của bác sỹ " + Tendaydu
        dr = SQLCmd.ExecuteReader()
        Dim row As Integer = 1
        grdChitietND_PPDT.Rows.Count = 1
        grdChitietND_PPDT.Redraw = False
        While dr.Read()
            grdChitietND_PPDT.Rows.Add()
            Dim i As Integer
            For i = 0 To dr.FieldCount - 1
                grdChitietND_PPDT(row, i) = dr.GetValue(i)
            Next
            row = row + 1
        End While
        dr.Close()
        SQLCmd.Dispose()
        grdChitietND_PPDT.Redraw = True
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdChitietND_PPDT, Lang)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim strID As String
        For i = 1 To grdChitietND_PPDT.Rows.Count - 1
            If (grdChitietND_PPDT.GetCellCheck(i, grdChitietND_PPDT.Cols("Chon").Index) = CheckEnum.Checked) Then
                strID = grdChitietND_PPDT(i, "ID_SoCD")
                SQLCmd.CommandText = "DELETE FROM [dbo].[tblSOTAYCHIDINH_CHITIET] WHERE ID_SoCD = " + strID
                SQLCmd.ExecuteNonQuery()
                SQLCmd.CommandText = "DELETE FROM [dbo].[tblSOTAYCHIDINH] WHERE ID_SoCD = " + strID
                SQLCmd.ExecuteNonQuery()
            End If
        Next
        SQLCmd.Dispose()
        Dim dr As System.Data.SqlClient.SqlDataReader
        SQLCmd.CommandText = "Select ID_SoCD,Mota from tblSOTAYCHIDINH WHERE Uname='" + TenDangNhap + "'"
        'Me.Text = "Sổ tay chỉ định của bác sỹ " + Tendaydu
        dr = SQLCmd.ExecuteReader()
        Dim row As Integer = 1
        grdChitietND_PPDT.Rows.Count = 1
        grdChitietND_PPDT.Redraw = False
        While dr.Read()
            grdChitietND_PPDT.Rows.Add()
            Dim j As Integer
            For j = 0 To dr.FieldCount - 1
                grdChitietND_PPDT(row, j) = dr.GetValue(j)
            Next
            row = row + 1
        End While
        dr.Close()
        SQLCmd.Dispose()
        grdChitietND_PPDT.Redraw = True

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class