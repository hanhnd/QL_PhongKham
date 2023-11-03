Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports VB6 = Microsoft.VisualBasic
Imports System.Drawing.Drawing2D
Imports C1.Win.C1FlexGrid
Imports C1.C1PrintDocument
Imports System.Data.OleDb
Imports System.Globalization
Public Class frmCLS_DichVuDaThuPhi

    Private Sub frmCLS_DichVuDaThuPhi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThuchien.Click
        Dim Sql As String = ""
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i, j, dem As Integer
        Dim Temp_XN As String = ""
        Try
            If txtTu.ValueIsDbNull Or txtDen.ValueIsDbNull Then
                MsgBox("Phải nhập khoảng thời gian báo cáo.", MsgBoxStyle.Critical, "Message!")
                Exit Sub
            End If
            If txtTu.Value > txtDen.Value Then
                MsgBox("Thời gian bắt đầu không được lớn hơn thời gian kết thúc.", MsgBoxStyle.Critical, "Message!")
                Exit Sub
            End If
            Sql = " SELECT Nhom.TenNhom,DV.TenDichvu As N'Tên dịch vụ'" _
                 & " ,Sum(CT.[Soluong]) As N'Số lượng' " _
                 & " ,Sum([Miengiam]) As N'Miễn giảm' " _
                 & " ,Sum([Thanhtien]) As N'Thành tiền' " _
                 & " FROM [dbo].[tblPHIEUTHANHTOAN] TT " _
                 & "   INNER JOIN [dbo].[tblPHIEUTHANHTOAN_CT] CT  ON TT.Sobienlai = CT.Sobienlai " _
                 & "   INNER JOIN DMDichVu DV ON CT.Madichvu = DV.MaDichvu " _
                 & "   INNER JOIN DMNHOMDICHVU_VP Nhom ON DV.NhomVP = Nhom.MaNhom" _
                & " where PhieuHuy = 0 AND Thoigianthanhtoan between '" & Format(txtTu.Value, "MM/dd/yyyy HH:mm:00") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm:59") & "'" _
                & " Group by Nhom.TenNhom,DV.TenDichvu " _
                & " order by Nhom.TenNhom,DV.TenDichvu"
            Cmd = New SqlClient.SqlCommand(Sql, Cn)
            Cmd.CommandTimeout = 0
            Adap = New SqlClient.SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "ThanhToan")
            grdDS.Cols(0).Visible = False
            grdDS.Tree.Column = 1
            grdDS.DataSource = DBNull.Value
            grdDS.Rows.Count = 1
            grdDS.Redraw = False

            If ds.Tables("ThanhToan").Rows.Count > 0 Then
                grdDS.DataSource = ds.Tables("ThanhToan")
            End If
            grdDS.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Tổng cộng:")
            grdDS.Subtotal(AggregateEnum.Sum, 1, 0, 4, "{0}")
            grdDS.Subtotal(AggregateEnum.Sum, 1, 0, 2, "{0}")
            grdDS.Cols(0).Visible = False

            grdDS.Tree.Show(1)
            grdDS.Tree.Show(2)
            grdDS.AutoSizeCols()
            grdDS.Cols(1).Width = 400
            grdDS.ExtendLastCol = True
            'grdDS.AllowEditing = False
            'grdDS.AllowSorting = AllowSortingEnum.None
            grdDS.Redraw = True

            ds.Dispose()
            Adap.Dispose()
            Cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdInBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInBC.Click
        Dim sql As String = ""
        Dim rpt As New rptTongHopThuPhiDichVu_ChiTiet
        sql = " SELECT Nhom.TenNhom,DV.TenDichvu " _
                 & " ,Sum(CT.[Soluong]) As SoLuong " _
                 & " ,Sum([Miengiam]) As MienGiam " _
                 & " ,Sum([Thanhtien]) As ThanhTien " _
                 & " FROM [dbo].[tblPHIEUTHANHTOAN] TT " _
                 & "   INNER JOIN [dbo].[tblPHIEUTHANHTOAN_CT] CT  ON TT.Sobienlai = CT.Sobienlai " _
                 & "   INNER JOIN DMDichVu DV ON CT.Madichvu = DV.MaDichvu " _
                 & "   INNER JOIN DMNHOMDICHVU_VP Nhom ON DV.NhomVP = Nhom.MaNhom" _
                & " where PhieuHuy = 0 AND Thoigianthanhtoan between '" & Format(txtTu.Value, "MM/dd/yyyy HH:mm:00") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm:59") & "'" _
                & " Group by Nhom.TenNhom,DV.TenDichvu " _
                & " order by Nhom.TenNhom,DV.TenDichvu"
        rpt.SQl = sql
        rpt.txtNgaythang.Text = "Từ: " + Format(txtTu.Value, "HH:mm dd/MM/yyyy") + " đến: " + Format(txtDen.Value, "HH:mm dd/MM/yyyy")
        'rpt.Run()
        rpt.Show()
    End Sub

    Private Sub cmdXuatExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuatExcel.Click
        Dim Tenfile As String = ""
        Dim Tensheet As String = ""
        Try
            If Format(txtTu.Value, "yyMMdd") = Format(txtDen.Value, "yyMMdd") Then
                Tensheet = "Ngay" + Format(txtTu.Value, "dd_MM_yyyy")
            Else
                Tensheet = String.Format("{0} {1}", Format(txtTu.Value, "dd_MM_yyyy"), Format(txtDen.Value, "dd_MM_yyyy"))
            End If

            SaveFileDialog1.Filter = "Excel |*.xls"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Tenfile = SaveFileDialog1.FileName
                'Tenfile = "C:\ThongKeThuDichVu_ChiTiet" & Format(txtTu.Value, "dd_MM_yyyy HH:mm") & ".xls"
                grdDS.SaveExcel(Tenfile, Tensheet, FileFlags.IncludeFixedCells)
                MsgBox(String.Format("Đã lưu vào file: {0} tại sheet: {1}", Tenfile, Tensheet))
            End If
            
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub
End Class