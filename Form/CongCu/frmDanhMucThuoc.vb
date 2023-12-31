Imports System.Data.SqlClient
Imports System.Data.Sql
Imports C1.Win.C1List
Public Class frmDanhMucThuoc
    Private Enum DMDV_TrangThai
        Them = 1
        Sua = 2
        Xem = 3
    End Enum
    Private DV_TT As DMDV_TrangThai
    Private Sub DMDVSetVisibleButtonForThemHoacSua(ByVal flag As Boolean)
        cmdThem.Visible = Not flag
        cmdSua.Visible = Not flag
        cmdGhi.Visible = flag
        cmdHuy.Visible = flag
        cmdXoa.Visible = Not flag
        cmdThoat.Visible = Not flag
    End Sub

    Private Sub frmCapNhatDMDonVi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DV_TT = DMDV_TrangThai.Xem
        DMDVLoadDSDonVi()
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdDMTHUOC, Lang)
    End Sub
    Private Sub DMDVLoadDSDonVi()
        Dim sqlCmd As SqlCommand
        Dim sqladapter As SqlDataAdapter
        Dim datatable As DataTable
        Dim i
        Try
            sqlCmd = New SqlCommand("", Cn)
            sqlCmd.CommandText = "SELECT * from " & TenDatabase & ".dbo.DMTHUOC"
            sqladapter = New SqlDataAdapter
            datatable = New DataTable
            sqladapter.SelectCommand = sqlCmd
            sqladapter.Fill(datatable)

            grdDMTHUOC.Rows.Count = 1
            grdDMTHUOC.Rows.Fixed = 1
            grdDMTHUOC.Redraw = False

            If datatable.Rows.Count > 0 Then
                For i = 0 To datatable.Rows.Count - 1
                    grdDMTHUOC.AddItem(CStr(i + 1) & vbTab & datatable.Rows(i).Item("ThuocID").ToString() _
                    & vbTab & datatable.Rows(i).Item("TenThuoc").ToString() _
                    & vbTab & datatable.Rows(i).Item("TenGoc").ToString() _
                    & vbTab & datatable.Rows(i).Item("Hamluong").ToString() _
                    & vbTab & datatable.Rows(i).Item("DonViTinh").ToString() _
                    & vbTab & datatable.Rows(i).Item("NoiSanXuat").ToString() _
                    & vbTab & datatable.Rows(i).Item("DonGia").ToString())
                Next
            End If
            grdDMTHUOC.AutoSizeRows()
            'grdDMTHUOC.AutoSizeCols()
            grdDMTHUOC.Redraw = True
            sqlCmd.Dispose()
            sqladapter.Dispose()
            datatable.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "PK")
        End Try
    End Sub
    Private Sub fgDanhsachDV_AfterRowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles grdDMTHUOC.AfterRowColChange
        If Not DV_TT = DMDV_TrangThai.Xem OrElse grdDMTHUOC.Row <= 0 Then Exit Sub
        DMDVLoadThongTinDonVi(grdDMTHUOC.Rows(grdDMTHUOC.Row))
    End Sub
    Private Sub DMDVLoadThongTinDonVi(ByVal fgrow As C1.Win.C1FlexGrid.Row)
        If grdDMTHUOC.Row <= 0 Then Exit Sub
        Try
            txtMaThuoc.Text = fgrow.Item("THUOCID").ToString()
            txtTenGoc.Text = fgrow.Item("TENGOC").ToString()
            txtTenThuoc.Text = fgrow.Item("TENTHUOC").ToString()
            txtHamLuong.Text = fgrow.Item("HAMLUONG").ToString()
            txtDVT.Text = fgrow.Item("DVT").ToString()
            txtNhaSanXuat.Text = fgrow.Item("NHASANXUAT").ToString()
            txtDonGia.Text = fgrow.Item("DONGIA").ToString()
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, "PK")
        End Try
    End Sub
    Private Sub DMDVSetEmptyForNew()
        txtMaThuoc.Text = ""
        txtTenGoc.Text = ""
        txtTenThuoc.Text = ""
        txtHamLuong.Text = ""
        txtDVT.Text = ""
        txtNhaSanXuat.Text = ""
        txtDonGia.Text = ""
    End Sub
    Private Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        DMDVSetVisibleButtonForThemHoacSua(True)
        DMDVSetEmptyForNew()
        txtMaThuoc.Text = LayMaThuoc(5)
        DV_TT = DMDV_TrangThai.Them
        txtMaThuoc.Enabled = True
        txtMaThuoc.Focus()
    End Sub

    Private Sub cmdSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSua.Click
        DMDVSetVisibleButtonForThemHoacSua(True)
        DV_TT = DMDV_TrangThai.Sua
        txtTenThuoc.Focus()
    End Sub
    Private Function KiemtraHL() As Boolean
        KiemtraHL = False
        If Trim(txtTenThuoc.Text) = "" Then
            MsgBox("Must enter drug name", MsgBoxStyle.Information, "Message !")
            txtTenThuoc.Focus()
            Exit Function
        End If
        If Trim(txtDVT.Text) = "" Then
            MsgBox("Must enter unit", MsgBoxStyle.Information, "Message !")
            txtDVT.Focus()
            Exit Function
        End If
        'If Val(Trim(txtDonGia.Text)) <= 0 Then
        '    MsgBox("Phải nhập đơn giá", MsgBoxStyle.Information, "Message !")
        '    txtDonGia.Focus()
        '    Exit Function
        'End If
        KiemtraHL = True
    End Function
    Private Function LayMaThuoc(ByVal DoDai As Integer) As String
        Dim SQL As String
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Try
            SQL = "Select ThuocID from " & TenDatabase & ".dbo.DMTHUOC  order by ThuocID desc"
            cmd = New SqlCommand(SQL, Cn)
            rd = cmd.ExecuteReader()
            If Not rd.HasRows Then
                LayMaThuoc = Replace(Space(DoDai - 1), " ", "0") & "1"
                rd.Close()
                cmd.Dispose()
                Exit Function
            End If
            'đọc phần tử đầu tiên
            If rd.Read Then
                Dim so As Integer = CInt(rd!ThuocID)
                so += 1
                LayMaThuoc = Replace(Space(DoDai - CStr(so).Length), " ", "0") & CStr(so)
            End If
            rd.Close()
            cmd.Dispose()
        Catch ex As Exception
        End Try
        Try
            rd.Close()
        Catch ex As Exception

        End Try
    End Function
    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        Dim MaThuoc, TenThuoc, TenGoc, DVT, NhaSanXuat, HamLuong As String
        Dim DonGia As Double
        Dim sqlStr As String
        Dim sqlcmd As SqlCommand
        Dim Tran As SqlTransaction
        Dim Dr As SqlDataReader

        If Not KiemtraHL() Then Exit Sub
        MaThuoc = "'" & Replace(Trim(txtMaThuoc.Text), "'", "''") & "'"
        TenGoc = "N'" & Replace(Trim(txtTenGoc.Text), "'", "''") & "'"
        TenThuoc = "N'" & Replace(Trim(txtTenThuoc.Text), "'", "''") & "'"
        HamLuong = "'" & Replace(Trim(txtHamLuong.Text), "'", "''") & "'"
        DVT = "N'" & Replace(Trim(txtDVT.Text), "'", "''") & "'"
        NhaSanXuat = "N'" & Replace(Trim(txtNhaSanXuat.Text), "'", "''") & "'"
        DonGia = Val(txtDonGia.Text.Trim)

        If DV_TT = DMDV_TrangThai.Them Then
            ' Ktra xem ThuocID đã có chưa?
            sqlStr = "Select * from " & TenDatabase & ".dbo.DMTHUOC WHERE ThuocID= " & MaThuoc
            sqlcmd = New SqlCommand(sqlStr, Cn)

            Dr = sqlcmd.ExecuteReader
            If Dr.HasRows Then
                MsgBox("Mã thuốc " + txtMaThuoc.Text + " đã tồn tại. Không cho phép thêm mới.", MsgBoxStyle.Critical, "PK")
                Dr.Close()
                Exit Sub
            End If
            Dr.Close()

            sqlStr = "Insert into " & TenDatabase & ".dbo.DMTHUOC ( TenThuoc,TenGoc, DonViTinh, HamLuong, NoiSanXuat, DonGia) " _
                      & " values (" & TenThuoc & ", " & TenGoc & "," & DVT & ", " & HamLuong & "," & NhaSanXuat & ", " & DonGia & ")  "
            sqlcmd = New SqlCommand(sqlStr, Cn)
            Try
                Tran = Cn.BeginTransaction()
                sqlcmd.Transaction = Tran
                sqlcmd.ExecuteNonQuery()
                Tran.Commit()
                DMDVSetVisibleButtonForThemHoacSua(False)
                DV_TT = DMDV_TrangThai.Xem
                DMDVLoadDSDonVi()
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message, MsgBoxStyle.Information, "PK")
                Exit Sub
            End Try

        ElseIf DV_TT = DMDV_TrangThai.Sua Then
            sqlStr = "update " & TenDatabase & ".dbo.DMTHUOC Set TenThuoc = " & TenThuoc & ",TenGoc=" & TenGoc & " " _
            & " ,HamLuong=" & HamLuong & ",DonViTinh=" & DVT & "" _
            & " ,NoiSanXuat=" & NhaSanXuat & ",DonGia=" & DonGia & "" _
            & " WHERE ThuocID= " & MaThuoc
            sqlcmd = New SqlCommand(sqlStr, Cn)
            Try
                Tran = Cn.BeginTransaction()
                sqlcmd.Transaction = Tran
                sqlcmd.ExecuteNonQuery()
                Tran.Commit()
                DV_TT = DMDV_TrangThai.Xem
                DMDVLoadDSDonVi()
                DMDVSetVisibleButtonForThemHoacSua(False)
                txtMaThuoc.Enabled = False
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message, MsgBoxStyle.Information, "PK")
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub cmdHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHuy.Click
        DMDVSetVisibleButtonForThemHoacSua(False)
        DV_TT = DMDV_TrangThai.Xem
        DMDVLoadThongTinDonVi(grdDMTHUOC.Rows(grdDMTHUOC.Row))
        txtMaThuoc.Enabled = False
    End Sub

    Private Sub cmdXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoa.Click
        If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo, "Request confirmation") = MsgBoxResult.Yes Then
            Try
                Dim MaThuoc As String = "'" & txtMaThuoc.Text.Trim() & "'"
                'Dim sqlcmd As New SqlCommand("Delete from " & HIS_SYSDB & ".dbo.DMDONVI where MaDonVi = " & MaDonVi, Cn)
                Dim sqlcmd As New SqlCommand("Update " & TenDatabase & ".dbo.DMTHUOC set Sudung = 1 where ThuocID = " & MaThuoc, Cn)
                sqlcmd.ExecuteNonQuery()
                grdDMTHUOC.Rows.Remove(grdDMTHUOC.Row)
            Catch ex As Exception
                MsgBox("Operation error, cannot delete: " & ex.Message, MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub btn_GetText_Click(sender As Object, e As EventArgs) Handles btn_GetText.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdDMTHUOC, "vi", Cn)
    End Sub
End Class