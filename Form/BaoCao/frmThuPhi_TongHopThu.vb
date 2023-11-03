Imports System.Data
Imports System.Data.SqlClient
Imports VB6 = Microsoft.VisualBasic
Imports System.IO
Imports System.Drawing.Drawing2D
Imports C1.Win.C1FlexGrid
Imports C1.C1PrintDocument
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Globalization
Public Class frmThuPhi_TongHopThu 'tên cũ frmDSBNnopDV.vb

    Private Sub SetPos_Start()
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i
        With grdThongkeBN
            ' Set Row 0,1
            .Rows.Count = 1
            .Cols.Count = 6
            .Rows.Fixed = 1
            .Styles.Fixed.WordWrap = True
            .AutoSizeRows()
            .Item(0, 1) = "TT"
            .Cols(1).Width = 25
            .Cols(1).Name = "ThuTu"
            .Item(0, 0) = "Nhóm dịch vụ"
            .Cols(0).Width = 60
            .Cols(0).Name = "NhomDichVu"
            '.Item(0, 1) = "Khoa phòng"
            '.Cols(1).Width = 60

            .Item(0, 2) = "Họ và tên"
            .Cols(2).Width = 180
            .Cols(2).Name = "HoTen"

            .Item(0, 3) = "Số tiền"
            .Cols(3).Width = 50
            .Cols(3).DataType = GetType(Double)
            .Cols(3).Format = "### ### ###"
            .Cols(3).Name = "SoTien"
            .Item(0, 4) = "Thời gian thanh toán"
            .Cols(4).Width = 100
            .Cols(4).Name = "ThoiGian"

            Dim cs2Cotcuoi As CellStyle = .Styles.Add("CotTong")
            cs2Cotcuoi.ForeColor = Color.Green
            cs2Cotcuoi.Font = New Font(.Font, FontStyle.Bold)
            .SelectionMode = SelectionModeEnum.Row
            .AllowEditing = False
            .Tree.Column = 2
            .Cols(0).Visible = False
            '.Cols(1).Visible = False
            .Cols(4).TextAlign = TextAlignEnum.RightCenter
            Dim cs0 As CellStyle = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            cs0.ForeColor = Color.Green
            cs0.BackColor = Color.White
            cs0.Font = New Font(.Font.Size, 12)
            Dim cs1 As CellStyle = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal1)
            cs1.ForeColor = Color.Navy
            cs1.BackColor = Color.White
            cs1.Font = New Font(.Font.Size, 10)
        End With
    End Sub
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        SQLStr = "Select * from DMLoaiDichVu "
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter
        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet
        Adap1.Fill(DsDM, "DMLoaiDichVu")
        Cmd1.Dispose()


        ' Them vao combo
        cmbNhomDV.DataSource = DsDM.Tables("DMLoaiDichVu")
        cmbNhomDV.DisplayMember = "TenLoaiDichVu"
        cmbNhomDV.ValueMember = "MaLoaiDichVu"
        cmbNhomDV.SelectedIndex = -1
        cmbNhomDV.AutoDropDown = True

        Adap1.Dispose()
        DsDM.Dispose()
        Adap1 = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub
    Private Sub frmThongke_Khambenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPos_Start()
        DocDM()
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdThongkeBN, Lang)
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub cmdThongke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThongke.Click
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i, j As Integer
        Dim Tongtien
        Dim tempNhom As String = ""
        Dim tempKhoa As String = ""
        Try
            If txtNgaykham.ValueIsDbNull Or txtDen.ValueIsDbNull Then Exit Sub
            tempNhom = IIf(cmbNhomDV.SelectedValue = Nothing, "", "where LoaiDichvu   =  " & cmbNhomDV.SelectedValue & " ")
            SQl = "Select d.TenLoaiDichVu, '' As Tenkhoa, Nguoinop_Hoten,  sum(Thanhtien) as Sotien,Q.Thoigianthanhtoan       " _
            & " FROM tblPHIEUTHANHTOAN Q  " _
            & " inner join (select * from tblPHIEUTHANHTOAN_CT  ) a on Q.Sobienlai = a.Sobienlai " _
            & " inner join (select * from DMDICHVU  " & tempNhom & "  ) b on a.Madichvu = b.Madichvu " _
             & " left join DMLoaiDichVu d on b.LoaiDichvu = d.MaLoaiDichVu " _
            & " where Q.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "' " _
            & " group by Q.sobienlai,TenLoaiDichVu,Nguoinop_Hoten,Q.Thoigianthanhtoan " _
            & " Union all " _
            & " Select  d.TenLoaiDichVu, '' As Tenkhoa, Nguoinop_Hoten,  - sum(Thanhtien) as Sotien,Q.Thoigianhuyphieu As Thoigianthanhtoan      " _
            & " FROM tblPHIEUTHANHTOAN Q  " _
            & " inner join (select * from tblPHIEUTHANHTOAN_CT) a on Q.Sobienlai = a.Sobienlai " _
            & " inner join (select * from DMDICHVU  " & tempNhom & "  ) b on a.Madichvu = b.Madichvu " _
             & " left join DMLoaiDichVu d on b.LoaiDichvu = d.MaLoaiDichVu " _
            & " where Q.Thoigianhuyphieu between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'   And Q.Phieuhuy =1 " _
            & " group by TenLoaiDichVu,Nguoinop_Hoten,Q.Thoigianhuyphieu order by TenLoaiDichVu,Tenkhoa,Thoigianthanhtoan"
            Cmd = New SqlCommand(SQl, Cn)
            rd = Cmd.ExecuteReader
            grdThongkeBN.Rows.Count = 1
            grdThongkeBN.Redraw = False
            Do While rd.Read
                i = i + 1
                grdThongkeBN.AddItem(rd!TenLoaiDichVu.ToString & vbTab & i.ToString.Trim() & vbTab & TenABC(rd!Nguoinop_Hoten.ToString) & vbTab & rd!Sotien & vbTab & Format(rd!Thoigianthanhtoan, "MM/dd/yyyy HH:mm"))
            Loop
            '& vbTab & rd!Tenkhoa.ToString
            rd.Close()
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 3, "Tổng cộng:")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 1, 0, 3, "{0}")
            'grdThongkeBN.Subtotal(AggregateEnum.Sum, 2, 1, 3, "{0}")
            grdThongkeBN.Tree.Show(1)
            grdThongkeBN.AutoSizeCols()
            grdThongkeBN.ExtendLastCol = True
            grdThongkeBN.Redraw = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdThongkeBN_AfterResizeColumn(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdThongkeBN.AfterResizeColumn
        grdThongkeBN.Styles.Fixed.WordWrap = True
        grdThongkeBN.AutoSizeRows()
    End Sub

    Private Sub cmdXuat_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuat_Excel.Click
        Dim Thoigian As String
        Thoigian = Format(txtNgaykham.Value, "yyyyMMddHHmm") + " _ " + Format(txtDen.Value, "yyyyMMddHHmm")
        Try
            If grdThongkeBN.Rows.Count < 4 Then Exit Sub
            If Not System.IO.Directory.Exists("D:\\PhieuThu") Then
                System.IO.Directory.CreateDirectory("D:\\PhieuThu")
            End If
            grdThongkeBN.SaveExcel("D:\\PhieuThu\\BaoCaoTongHopThuPhi_" + String.Format("{0:ddMMyyyy}", txtNgaykham.Value) + ".xls", Thoigian, FileFlags.IncludeFixedCells)
            MsgBox("Exported to file D:\\PhieuThu\\BaoCaoTongHopThuPhi_" + String.Format("{0:ddMMyyyy}", txtNgaykham.Value) + ".xls" + ", tại Sheet: " + Thoigian, MsgBoxStyle.Information, "Message!")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdInDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInDS.Click
        Dim sql As String = ""
        Dim rpt As New rptDSBNNopDV
        Dim rpt_Khoa As New rptDSBNNopDV_Khoa
        Dim tempNhom As String = ""
        If txtNgaykham.ValueIsDbNull Or txtDen.ValueIsDbNull Then Exit Sub
        If Not cmbNhomDV.SelectedValue = Nothing Then
            tempNhom = "where LoaiDichvu = " & cmbNhomDV.SelectedValue & " "
        End If
        sql = "Select  Q.Thoigianthanhtoan,d.TenLoaiDichvu As Tennhom, Nguoinop_Hoten,  sum(Thanhtien) as Sotien       " _
                   & " FROM tblPHIEUTHANHTOAN Q  " _
                   & " inner join (select * from tblPHIEUTHANHTOAN_CT ) a on Q.Sobienlai = a.Sobienlai " _
                   & " inner join (select * from DMDICHVU  " + tempNhom + " ) b on a.Madichvu = b.Madichvu " _
                    & " left join DMLoaiDichVu d on b.LoaiDichvu = d.MaLoaiDichVu " _
                   & " where Q.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'   And (Q.Phieuhuy Is null Or Q.Phieuhuy = 0) " _
                   & " group by Thoigianthanhtoan,TenLoaiDichvu,Nguoinop_Hoten order by Q.Thoigianthanhtoan,Nguoinop_Hoten,TenLoaiDichvu"
        rpt.SQl = sql
            rpt.txtNgaythang.Text = "Từ: " + Format(txtNgaykham.Value, "HH:mm dd/MM/yyyy") + " đến: " + Format(txtDen.Value, "HH:mm dd/MM/yyyy")
            rpt.Label11.Text = "Nộp tiền dịch vụ " + cmbNhomDV.Text
            'rpt.Run()
            rpt.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdThongkeBN, "vi", Cn)
    End Sub
End Class