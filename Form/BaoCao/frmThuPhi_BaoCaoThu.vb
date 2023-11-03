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
'Imports Excel

Public Class frmThuPhi_BaoCaoThu ' tên cũ frmBCTonghopThuDV.vb
    Private Sub SetPos_Start()
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i
        With grdThongkeBN
            ' Set Row 0,1
            .Rows.Count = 1
            .Cols.Count = 7
            .Rows.Fixed = 1
            .Styles.Fixed.WordWrap = True
            .AutoSizeRows()
            .Item(0, 0) = "Nhân viên TT"
            .Cols(0).Width = 80

            .Item(0, 1) = "TT"
            .Cols(1).Width = 25

            .Item(0, 2) = "Số biên lai"
            .Cols(2).Width = 60

            .Item(0, 3) = "Họ và tên"
            .Cols(3).Width = 100

            .Item(0, 4) = "Khoa"
            .Cols(4).Width = 38

            .Item(0, 5) = "Tổng thu"
            .Cols(5).Width = 50
            .Cols(5).DataType = GetType(Double)
            .Cols(5).Format = "### ### ###"

            .Item(0, 6) = "Tổng chi"
            .Cols(6).Width = 50
            .Cols(6).DataType = GetType(Double)
            .Cols(6).Format = "### ### ###"

            SQl = "select Manhom, Tentat  from DMNHOMDICHVU_VP " 'where Noitru_Ngoaitru <> 1  "
            Cmd = New SqlCommand(SQl, Cn)
            rd = Cmd.ExecuteReader
            Do While rd.Read
                .Cols.Add()
                .Item(0, .Cols.Count - 1) = rd!Tentat
                .Cols(.Cols.Count - 1).UserData = rd!Manhom
                .Cols(.Cols.Count - 1).Width = 70
                .Cols(.Cols.Count - 1).DataType = GetType(Double)
                .Cols(.Cols.Count - 1).Format = "### ### ###"
                .Cols(.Cols.Count - 1).TextAlign = TextAlignEnum.RightCenter
                .Cols(.Cols.Count - 1).TextAlignFixed = TextAlignEnum.CenterCenter
            Loop
            rd.Close()
            .Styles.Fixed.WordWrap = True
            .SelectionMode = SelectionModeEnum.Row
            .AllowEditing = False
            .AutoSizeRows()
            .Tree.Column = 3
            .Cols(0).Visible = False
            .SubtotalPosition = SubtotalPositionEnum.BelowData
        End With
    End Sub

    Private Sub frmThongke_Khambenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPos_Start()
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    'Private Sub cmdThongke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThongke.Click
    '    Dim SQl As String
    '    Dim Cmd As SqlCommand
    '    Dim rd As SqlDataReader
    '    Dim Adap As SqlDataAdapter
    '    Dim ds As DataSet
    '    Dim i, j As Integer
    '    Dim Tongtien
    '    Try
    '        If txtNgaykham.ValueIsDbNull Or txtDen.ValueIsDbNull Then Exit Sub
    '        grdThongkeBN.Rows.Count = 1
    '        'SQl = " Select * from " _
    '        '& " (Select  a.Sobienlai as [Số biên lai], a.Nguoinop_Hoten as [Họ và tên], a.Nguoinop_Khoa as [Khoa] ,   a.Sotien as Thu, 0 as Chi, " _
    '        '& " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT  " _
    '        '& "  where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 1)  as [Khám-ÐT],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 7)  as [Khám CK],  " _
    '        '& "  (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 4)  as [Giuờng],  " _
    '        '  & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 13)  as [PHCN],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 2)  as [TT, ngoại khoa],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 10)  as [Soi],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 25)  as [Sản],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 26)  as [Mắt],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 27)  as [TMH],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 28)  as [RHM],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 29)  as [PT Nội soi],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom= 5)  as [Xét nghiệm],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 3)  as [Ðiện tim],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 9)  as [Siêu âm],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 14)  as [Ðiện não],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 23)  as [Men tim],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 22)  as [CT],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 6)  as [XQ],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 31)  as [DCKX],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 32)  as [VT mắt],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 21)  as [Lazer],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 33)  as [Thuốc ÐY],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 34)  as [Giấy CS],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 16)  as [DV Tang lễ],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 15)  as [Xe],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 30)  as [Quân trang],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 12)  as [DV Nguời nhà BN],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 8)  as [Thuốc],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 11)  as [CC - BH],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 17)  as [VTTH PT mở],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 19)  as [Công PT mở],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 20)  as [VTPT],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 18)  as [Khác]  " _
    '        ' & " FROM tblPHIEUTHANHTOAN a  where a.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'   " _
    '        ' & " union all " _
    '        '& " Select  a.Sobienlai as [Số biên lai], a.Nguoinop_Hoten as [Họ và tên], a.Nguoinop_Khoa as [Khoa] ,  0 as Thu,  a.Sotien as Chi, " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT  " _
    '        '& "  where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 1)  as [Khám-ÐT],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 7)  as [Khám CK],  " _
    '        '& "  (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 4)  as [Giu?ng],  " _
    '        '  & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 13)  as [PHCN],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 2)  as [TT, ngoại khoa],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 10)  as [Soi],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 25)  as [Sản],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 26)  as [Mắt],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 27)  as [TMH],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 28)  as [RHM],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 29)  as [PT Nội soi],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom= 5)  as [Xét nghiệm],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 3)  as [Ðiện tim],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 9)  as [Siêu âm],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 14)  as [Ðiện não],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 23)  as [Men tim],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 22)  as [CT],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 6)  as [XQ],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 31)  as [DCKX],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 32)  as [VT mắt],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 21)  as [Lazer],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        '  & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 33)  as [Thuốc ÐY],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 34)  as [Giấy CS],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 16)  as [DV Tang lễ],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 15)  as [Xe],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 30)  as [Quân trang],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 12)  as [DV Nguời nhà BN],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 8)  as [Thuốc],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 11)  as [CC - BH],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 17)  as [VTTH PT mở],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 19)  as [Công PT mở],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 20)  as [VTPT],  " _
    '        ' & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        ' & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 18)  as [Khác]  " _
    '        ' & " FROM tblPHIEUTHANHTOAN a  where a.Thoigianhuyphieu between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'  and a.Phieuhuy = 1)Q  " _
    '        ' & " order by [Số biên lai]"

    '        SQl = "Select  a.Sobienlai as [Số biên lai], a.Nguoinop_Hoten as [Họ và tên], a.Nguoinop_Khoa as [Khoa] ,   a.Sotien as Thu, 0 as Chi, " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT  " _
    '       & "  where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 1)  as [Khám-ÐT],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 7)  as [Khám CK],  " _
    '       & "  (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 4)  as [Giuờng],  " _
    '         & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 13)  as [PHCN],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 2)  as [TT, ngoại khoa],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 10)  as [Soi],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 25)  as [Sản],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 26)  as [Mắt],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 27)  as [TMH],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 28)  as [RHM],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 29)  as [PT Nội soi],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom= 5)  as [Xét nghiệm],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 3)  as [Ðiện tim],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 9)  as [Siêu âm],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 14)  as [Ðiện não],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 23)  as [Men tim],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 22)  as [CT],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 6)  as [XQ],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 31)  as [DCKX],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 32)  as [VT mắt],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 21)  as [Lazer],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '         & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 33)  as [Thuốc ÐY],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 34)  as [Giấy CS],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 16)  as [DV Tang lễ],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 15)  as [Xe],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 30)  as [Quân trang],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 12)  as [DV Nguời nhà BN],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 8)  as [Thuốc],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 11)  as [CC - BH],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 17)  as [VTTH PT mở],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 19)  as [Công PT mở],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 20)  as [VTPT],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 18)  as [Khác]  " _
    '        & " FROM tblPHIEUTHANHTOAN a  where a.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'   " _
    '        & " order by [Số biên lai]"
    '        Cmd = New SqlCommand(SQl, Cn)
    '        Adap = New SqlDataAdapter
    '        Adap.SelectCommand = Cmd
    '        ds = New DataSet
    '        Adap.Fill(ds, "Hoso")
    '        grdThongkeBN.Redraw = False
    '        If ds.Tables("Hoso").Rows.Count > 0 Then
    '            For i = 0 To ds.Tables("Hoso").Rows.Count - 1
    '                grdThongkeBN.AddItem(grdThongkeBN.Rows.Count & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Số biên lai") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Họ và tên") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Khoa") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Thu") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Chi") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Khám-ÐT") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Khám CK") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Giuờng") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("PHCN") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("TT, ngoại khoa") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Soi") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Sản") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Mắt") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("TMH") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("RHM") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("PT Nội soi") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Xét nghiệm") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Ðiện tim") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Siêu âm") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Ðiện não") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Men tim") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("CT") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("XQ") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("DCKX") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("VT mắt") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Lazer") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Thuốc ÐY") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Giấy CS") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("DV Tang lễ") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Xe") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Quân trang") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("DV Nguời nhà BN") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Thuốc") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("CC - BH") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("VTTH PT mở") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Công PT mở") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("VTPT") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Khác"))
    '            Next
    '        End If
    '        ds.Dispose()
    '        Adap.Dispose()
    '        Cmd.Dispose()
    '        SQl = " Select  a.Sobienlai as [Số biên lai], a.Nguoinop_Hoten as [Họ và tên], a.Nguoinop_Khoa as [Khoa] ,  0 as Thu,  a.Sotien as Chi, " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT  " _
    '      & "  where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 1)  as [Khám-ÐT],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 7)  as [Khám CK],  " _
    '      & "  (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 4)  as [Giuờng],  " _
    '        & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 13)  as [PHCN],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 2)  as [TT, ngoại khoa],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 10)  as [Soi],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 25)  as [Sản],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 26)  as [Mắt],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 27)  as [TMH],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 28)  as [RHM],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 29)  as [PT Nội soi],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom= 5)  as [Xét nghiệm],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 3)  as [Ðiện tim],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 9)  as [Siêu âm],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 14)  as [Ðiện não],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 23)  as [Men tim],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 22)  as [CT],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 6)  as [XQ],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 31)  as [DCKX],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 32)  as [VT mắt],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 21)  as [Lazer],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '        & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 33)  as [Thuốc ÐY],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 34)  as [Giấy CS],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 16)  as [DV Tang lễ],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 15)  as [Xe],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 30)  as [Quân trang],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 12)  as [DV Nguời nhà BN],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 8)  as [Thuốc],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 11)  as [CC - BH],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 17)  as [VTTH PT mở],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 19)  as [Công PT mở],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 20)  as [VTPT],  " _
    '       & " (select  isnull (sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia),0) from viewPHIEUTHANHTOAN_CT    " _
    '       & " where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai and viewPHIEUTHANHTOAN_CT.Manhom = 18)  as [Khác]  " _
    '       & " FROM tblPHIEUTHANHTOAN a  where a.Thoigianhuyphieu between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'  and a.Phieuhuy = 1  " _
    '       & " order by [Số biên lai]"
    '        Cmd = New SqlCommand(SQl, Cn)
    '        Adap = New SqlDataAdapter
    '        Adap.SelectCommand = Cmd
    '        ds = New DataSet
    '        Adap.Fill(ds, "Hoso")
    '        If ds.Tables("Hoso").Rows.Count > 0 Then
    '            For i = 0 To ds.Tables("Hoso").Rows.Count - 1
    '                grdThongkeBN.AddItem(grdThongkeBN.Rows.Count & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Số biên lai") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Họ và tên") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Khoa") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Thu") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Chi") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Khám-ÐT") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Khám CK") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Giuờng") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("PHCN") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("TT, ngoại khoa") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Soi") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Sản") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Mắt") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("TMH") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("RHM") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("PT Nội soi") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Xét nghiệm") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Ðiện tim") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Siêu âm") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Ðiện não") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Men tim") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("CT") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("XQ") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("DCKX") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("VT mắt") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Lazer") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Thuốc ÐY") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Giấy CS") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("DV Tang lễ") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Xe") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Quân trang") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("DV Nguời nhà BN") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Thuốc") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("CC - BH") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("VTTH PT mở") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Công PT mở") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("VTPT") & _
    '                vbTab & ds.Tables("Hoso").Rows(i).Item("Khác"))
    '            Next
    '        End If
    '        ds.Dispose()
    '        Adap.Dispose()
    '        Cmd.Dispose()
    '        Dim Nodata As Boolean
    '        If grdThongkeBN.Rows.Count > 1 Then
    '            For i = 6 To grdThongkeBN.Cols.Count - 1
    '                Nodata = True
    '                For j = 1 To grdThongkeBN.Rows.Count - 1
    '                    If Val(grdThongkeBN.Item(j, i)) <> 0 Then
    '                        Nodata = False
    '                        'Exit For
    '                    Else
    '                        grdThongkeBN.Item(j, i) = ""
    '                    End If
    '                Next
    '                grdThongkeBN.Cols(i).Visible = Not Nodata
    '            Next
    '        End If
    '        For i = 4 To grdThongkeBN.Cols.Count - 1
    '            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, i, "Tổng cộng: ")
    '        Next
    '        grdThongkeBN.AutoSizeCols()
    '        grdThongkeBN.Redraw = True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try


    '    '*********CODE cũ***********************************************************************************
    '    'Dim SQl As String
    '    'Dim Cmd As SqlCommand
    '    'Dim rd As SqlDataReader
    '    'Dim i, j As Integer
    '    'Dim Tongtien
    '    'Try
    '    '    If txtNgaykham.ValueIsDbNull Or txtDen.ValueIsDbNull Then Exit Sub
    '    '    SQl = "Select  Q.Sobienlai,Q.Nguoinop_Hoten, Q.Nguoinop_Khoa ,  " _
    '    '    & " Q.Sotien  " _
    '    '    & " FROM tblPHIEUTHANHTOAN Q " _
    '    '    & " where Q.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'  and (Phieuhuy  is null or Phieuhuy = 0) "
    '    '    Cmd = New SqlCommand(SQl, Cn)
    '    '    rd = Cmd.ExecuteReader
    '    '    grdThongkeBN.Rows.Count = 1
    '    '    grdThongkeBN.Redraw = False
    '    '    Do While rd.Read
    '    '        i = i + 1
    '    '        grdThongkeBN.AddItem(i.ToString.Trim() & vbTab & rd!Sobienlai.ToString & vbTab & TenABC(rd!Nguoinop_Hoten.ToString) & vbTab & rd!Nguoinop_Khoa.ToString & vbTab & rd!Sotien)
    '    '     Loop
    '    '    rd.Close()
    '    '    If grdThongkeBN.Rows.Count < 2 Then Exit Sub
    '    '    For i = 1 To grdThongkeBN.Rows.Count - 1
    '    '        Tongtien = 0
    '    '        For j = 5 To grdThongkeBN.Cols.Count - 1
    '    '            SQl = "Select sum(soluong*a.Dongia) as Thanhtien " _
    '    '            & " FROM tblPHIEUTHANHTOAN_CT  a" _
    '    '            & " left outer join DMDICHVU b on a.Madichvu = b.Madichvu " _
    '    '            & " where Sobienlai  = '" & grdThongkeBN.Item(i, 1) & "' and " _
    '    '            & " b. NhomVPNT_DV = " & grdThongkeBN.Cols(j).UserData & " group by NhomVPNT_DV "
    '    '            Cmd.CommandText = SQl
    '    '            rd = Cmd.ExecuteReader
    '    '            Do While rd.Read
    '    '                grdThongkeBN.Item(i, j) = rd!Thanhtien
    '    '                'Tongtien = Tongtien + rd!Thanhtien
    '    '            Loop
    '    '            rd.Close()
    '    '        Next
    '    '    Next

    '    '    Dim rg As CellRange = grdThongkeBN.GetCellRange(1, 4, grdThongkeBN.Rows.Count - 1, 4)
    '    '    rg.Style = grdThongkeBN.Styles("CotTong")
    '    '    For i = 4 To grdThongkeBN.Cols.Count - 1
    '    '        grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, i, "Tổng cộng:")
    '    '        grdThongkeBN.Cols(i).Width = 70
    '    '    Next
    '    '    '            grdThongkeBN.AutoSizeCols(1, 0, grdThongkeBN.Rows.Count - 1, grdThongkeBN.Cols.Count - 1, 0, AutoSizeFlags.IgnoreHidden)
    '    '    'grdThongkeBN.Tree.Column = 2
    '    '    'Dim cs0 As CellStyle = grdThongkeBN.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
    '    '    'cs0.ForeColor = Color.Blue
    '    '    'cs0.BackColor = Color.White
    '    '    'grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, 5, 5, "Tổng cộng: ")
    '    '    grdThongkeBN.Redraw = True
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'End Try
    'End Sub
    Private Sub cmdThongke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThongke.Click
        '------Lệnh thống kê cũ ko chia theo nhân viên------------
        'Dim SQl As String
        'Dim Cmd As SqlCommand
        'Dim rd As SqlDataReader
        'Dim Adap As SqlDataAdapter
        'Dim ds As DataSet
        'Dim i, j As Integer
        'Dim Tong_hang = 0
        'Dim Temp_Sobl As String = ""
        'SetPos_Start()
        'Try
        '    If txtNgaykham.ValueIsDbNull Or txtDen.ValueIsDbNull Then Exit Sub
        '    grdThongkeBN.Redraw = False
        '    'Load phieu thu
        '    SQl = "Select  a.Sobienlai  , a.Nguoinop_Hoten  , a.Nguoinop_Khoa  , Manhom,  " _
        '   & "  sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia) as Nhom_tien from tblPHIEUTHANHTOAN a,viewPHIEUTHANHTOAN_CT  " _
        '   & "  where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai    and  a.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'   " _
        '    & " group by a.Sobienlai, Nguoinop_hoten,Nguoinop_khoa, Manhom order by  cast(a.Sobienlai as numeric)"
        '    Cmd = New SqlCommand(SQl, Cn)
        '    Adap = New SqlDataAdapter
        '    Adap.SelectCommand = Cmd
        '    ds = New DataSet
        '    Adap.Fill(ds, "Hoso")
        '    If ds.Tables("Hoso").Rows.Count > 0 Then
        '        Temp_Sobl = ""
        '        For i = 0 To ds.Tables("Hoso").Rows.Count - 1
        '            If Temp_Sobl <> ds.Tables("Hoso").Rows(i).Item("Sobienlai") Then grdThongkeBN.AddItem(grdThongkeBN.Rows.Count & vbTab & ds.Tables("Hoso").Rows(i).Item("Sobienlai") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_hoten") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Khoa")) ' Sang số BL mới
        '            For j = 6 To grdThongkeBN.Cols.Count - 1
        '                If grdThongkeBN.Cols(j).UserData = ds.Tables("Hoso").Rows(i).Item("Manhom") Then
        '                    grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, j) = ds.Tables("Hoso").Rows(i).Item("Nhom_tien")
        '                    Exit For
        '                End If
        '            Next
        '            grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 4) += ds.Tables("Hoso").Rows(i).Item("Nhom_tien")
        '            Temp_Sobl = ds.Tables("Hoso").Rows(i).Item("Sobienlai")
        '        Next
        '    End If
        '    ds.Dispose()
        '    Adap.Dispose()
        '    Cmd.Dispose()
        '    'Load phieu hủy
        '    SQl = "Select  a.Sobienlai, a.Nguoinop_Hoten  , a.Nguoinop_Khoa  , Manhom,   " _
        '               & "  sum (- viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia) as Nhom_tien from tblPHIEUTHANHTOAN a,viewPHIEUTHANHTOAN_CT  " _
        '               & "  where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai    and  a.Thoigianhuyphieu between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "' and Phieuhuy = 1  " _
        '                & " group by a.Sobienlai, Nguoinop_hoten,Nguoinop_khoa, Manhom order by   cast(a.Sobienlai as numeric)"
        '    Cmd = New SqlCommand(SQl, Cn)
        '    Adap = New SqlDataAdapter
        '    Adap.SelectCommand = Cmd
        '    ds = New DataSet
        '    Adap.Fill(ds, "Hoso")
        '    If ds.Tables("Hoso").Rows.Count > 0 Then
        '        Temp_Sobl = ""
        '        For i = 0 To ds.Tables("Hoso").Rows.Count - 1
        '            If Temp_Sobl <> ds.Tables("Hoso").Rows(i).Item("Sobienlai") Then grdThongkeBN.AddItem(grdThongkeBN.Rows.Count & vbTab & ds.Tables("Hoso").Rows(i).Item("Sobienlai") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_hoten") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Khoa")) ' Sang số BL mới
        '            For j = 6 To grdThongkeBN.Cols.Count - 1
        '                If grdThongkeBN.Cols(j).UserData = ds.Tables("Hoso").Rows(i).Item("Manhom") Then
        '                    grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, j) = ds.Tables("Hoso").Rows(i).Item("Nhom_tien")
        '                    Exit For
        '                End If
        '            Next
        '            grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 5) += ds.Tables("Hoso").Rows(i).Item("Nhom_tien")
        '            Temp_Sobl = ds.Tables("Hoso").Rows(i).Item("Sobienlai")
        '        Next
        '    End If
        '    ds.Dispose()
        '    Adap.Dispose()
        '    Cmd.Dispose()
        '    'Ẩn các cột trắng
        '    Dim Nodata As Boolean
        '    If grdThongkeBN.Rows.Count > 1 Then
        '        For i = 6 To grdThongkeBN.Cols.Count - 1
        '            Nodata = True
        '            For j = 1 To grdThongkeBN.Rows.Count - 1
        '                If Not grdThongkeBN.Item(j, i) Is Nothing Then
        '                    Nodata = False
        '                    Exit For
        '                End If
        '            Next
        '            grdThongkeBN.Cols(i).Visible = Not Nodata
        '        Next
        '    Else
        '        Exit Sub
        '    End If
        '    For i = 4 To grdThongkeBN.Cols.Count - 1
        '        grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, i, "Tổng cộng: ")
        '    Next
        '    grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 2) = "Tổng cộng: " + Format(grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 4) + grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 5), "### ### ### ###")
        '    grdThongkeBN.AutoSizeCols()
        '    grdThongkeBN.Redraw = True
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        '---------------------------------------------
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i, j As Integer
        Dim Tong_hang = 0
        Dim Temp_Sobl As String = ""
        Dim Temp_Nhanvien1 As String = ""
        Dim Temp_Nhanvien2 As String = ""
        SetPos_Start()
        Try
            If chkNhanvien.Checked Then
                Temp_Nhanvien1 = " and a.Nhanvienthanhtoan = N'" & Tendangnhap & "'  "
                Temp_Nhanvien2 = " and a.Nhanvienhuyphieu = N'" & Tendangnhap & "'  "
            End If

            If txtNgaykham.ValueIsDbNull Or txtDen.ValueIsDbNull Then Exit Sub
            grdThongkeBN.Redraw = False
            'Load phieu thu ===& " sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia) as Nhom_tien " _
            SQl = "select Q.*, c.Tendu from (Select  a.Sobienlai  , a.Nguoinop_Hoten  , isnull(a.Nguoinop_Khoa,'') As Nguoinop_Khoa  , Manhom,Nhanvienthanhtoan ,   " _
            & " sum (ViewPHIEUTHANHTOAN_CT.ThanhTien) As Nhom_tien " _
            & " from tblPHIEUTHANHTOAN a,viewPHIEUTHANHTOAN_CT where(a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai)" _
            & " and  a.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "' " & Temp_Nhanvien1 & " " _
            & " group by a.Sobienlai, Nguoinop_hoten,Nguoinop_khoa, Manhom, Nhanvienthanhtoan)Q " _
            & " left join SYSUSER c on Q.Nhanvienthanhtoan = c.Uname " _
            & " order by  Tendu,cast(Q.Sobienlai as numeric) "
            'Select  a.Sobienlai  , a.Nguoinop_Hoten  , a.Nguoinop_Khoa  , Manhom,  " _
            '           & "  sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia) as Nhom_tien from tblPHIEUTHANHTOAN a,viewPHIEUTHANHTOAN_CT  " _
            '           & "  where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai    and  a.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'   " _
            '            & " group by a.Sobienlai, Nguoinop_hoten,Nguoinop_khoa, Manhom order by  cast(a.Sobienlai as numeric)"
            Cmd = New SqlCommand(SQl, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                Temp_Sobl = ""
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    If Temp_Sobl <> ds.Tables("Hoso").Rows(i).Item("Sobienlai") Then grdThongkeBN.AddItem(ds.Tables("Hoso").Rows(i).Item("Tendu") & vbTab & grdThongkeBN.Rows.Count & vbTab & ds.Tables("Hoso").Rows(i).Item("Sobienlai") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_hoten") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Khoa")) ' Sang số BL mới
                    For j = 7 To grdThongkeBN.Cols.Count - 1
                        If grdThongkeBN.Cols(j).UserData = ds.Tables("Hoso").Rows(i).Item("Manhom") Then
                            grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, j) = ds.Tables("Hoso").Rows(i).Item("Nhom_tien")
                            Exit For
                        End If
                    Next
                    grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 5) += ds.Tables("Hoso").Rows(i).Item("Nhom_tien")
                    Temp_Sobl = ds.Tables("Hoso").Rows(i).Item("Sobienlai")
                Next
            End If
            ds.Dispose()
            Adap.Dispose()
            Cmd.Dispose()
            'Load phieu hủy == & " sum (- viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia) as Nhom_tien " _

            SQl = "select Q.*, c.Tendu from (Select  a.Sobienlai  , a.Nguoinop_Hoten  , a.Nguoinop_Khoa  , Manhom,Nhanvienhuyphieu ,   " _
            & " sum (- ViewPHIEUTHANHTOAN_CT.ThanhTien) As Nhom_tien " _
            & " from tblPHIEUTHANHTOAN a,viewPHIEUTHANHTOAN_CT where(a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai)" _
            & " and  a.Thoigianhuyphieu between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'  and Phieuhuy = 1 " & Temp_Nhanvien2 & "   " _
            & " group by a.Sobienlai, Nguoinop_hoten,Nguoinop_khoa, Manhom, Nhanvienhuyphieu)Q " _
            & " left join SYSUSER c on Q.Nhanvienhuyphieu = c.Uname " _
            & " order by  Tendu,cast(Q.Sobienlai as numeric) "

            'SQl = "select Q.*, c.Tendu from (Select  a.Sobienlai  , a.Nguoinop_Hoten  , a.Nguoinop_Khoa  , Manhom,Nhanvienthanhtoan ,   " _
            '           & " sum (viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia) as Nhom_tien " _
            '           & " from tblPHIEUTHANHTOAN a,viewPHIEUTHANHTOAN_CT where(a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai)" _
            '           & " and  a.Thoigianthanhtoan between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "'  and Phieuhuy = 1 " & Temp_Nhanvien & "   " _
            '           & " group by a.Sobienlai, Nguoinop_hoten,Nguoinop_khoa, Manhom, Nhanvienthanhtoan)Q " _
            '           & " left join SYSUSER c on Q.Nhanvienthanhtoan = c.Uname " _
            '           & " order by  Tendu,cast(Q.Sobienlai as numeric) "
            'SQl = "Select  a.Sobienlai, a.Nguoinop_Hoten  , a.Nguoinop_Khoa  , Manhom,   " _
            '           & "  sum (- viewPHIEUTHANHTOAN_CT.Soluong * viewPHIEUTHANHTOAN_CT.Dongia) as Nhom_tien from tblPHIEUTHANHTOAN a,viewPHIEUTHANHTOAN_CT  " _
            '           & "  where a.Sobienlai = viewPHIEUTHANHTOAN_CT.Sobienlai    and  a.Thoigianhuyphieu between '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "' and Phieuhuy = 1  " _
            '            & " group by a.Sobienlai, Nguoinop_hoten,Nguoinop_khoa, Manhom order by   cast(a.Sobienlai as numeric)"
            Cmd = New SqlCommand(SQl, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                Temp_Sobl = ""
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    If Temp_Sobl <> ds.Tables("Hoso").Rows(i).Item("Sobienlai") Then grdThongkeBN.AddItem(ds.Tables("Hoso").Rows(i).Item("Tendu") & vbTab & grdThongkeBN.Rows.Count & vbTab & ds.Tables("Hoso").Rows(i).Item("Sobienlai") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_hoten") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Khoa")) ' Sang số BL mới
                    For j = 7 To grdThongkeBN.Cols.Count - 1
                        If grdThongkeBN.Cols(j).UserData = ds.Tables("Hoso").Rows(i).Item("Manhom") Then
                            grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, j) = ds.Tables("Hoso").Rows(i).Item("Nhom_tien")
                            Exit For
                        End If
                    Next
                    grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 6) += ds.Tables("Hoso").Rows(i).Item("Nhom_tien")
                    Temp_Sobl = ds.Tables("Hoso").Rows(i).Item("Sobienlai")
                Next
            End If
            ds.Dispose()
            Adap.Dispose()
            Cmd.Dispose()
            'Ẩn các cột trắng
            Dim Nodata As Boolean
            If grdThongkeBN.Rows.Count > 1 Then
                For i = 7 To grdThongkeBN.Cols.Count - 1
                    Nodata = True
                    For j = 1 To grdThongkeBN.Rows.Count - 1
                        If Not grdThongkeBN.Item(j, i) Is Nothing Then
                            Nodata = False
                            Exit For
                        End If
                    Next
                    grdThongkeBN.Cols(i).Visible = Not Nodata
                Next
            Else
                Exit Sub
            End If
            For i = 5 To grdThongkeBN.Cols.Count - 1
                grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, i, "Tổng cộng: ")
            Next
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 1, 0, 5, "{0}")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 1, 0, 6, "{0}")
            grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 3) = "Tổng cộng: " + Format(grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 5) + grdThongkeBN.Item(grdThongkeBN.Rows.Count - 1, 6), "### ### ### ###")
            grdThongkeBN.AutoSizeCols()
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
            grdThongkeBN.Cols.Remove(0)
            grdThongkeBN.Rows.Insert(0)
            grdThongkeBN.Rows.Insert(0)
            grdThongkeBN.Rows.Insert(0)

            grdThongkeBN.SaveExcel("D:\\PhieuThu\\BaoCaoThuPhi_ChiTiet_" + String.Format("{0:ddMMyyyy}", txtNgaykham.Value) + ".xls", Thoigian, FileFlags.IncludeFixedCells)
            grdThongkeBN.RemoveItem(0)
            grdThongkeBN.RemoveItem(0)
            grdThongkeBN.RemoveItem(0)
            grdThongkeBN.Cols.Insert(0)
            MsgBox("Exported to file D:\\PhieuThu\\BaoCaoThuPhi_ChiTiet_" + String.Format("{0:ddMMyyyy}", txtNgaykham.Value) + ".xls" + ", tại Sheet: " + Thoigian, MsgBoxStyle.Information, "Message!")
            Format_ExcelFile("D:\\PhieuThu\\BaoCaoThuPhi_ChiTiet_" + String.Format("{0:ddMMyyyy}", txtNgaykham.Value) + ".xls", Thoigian)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Format_ExcelFile(ByVal fileName As String, ByVal Sheet_Name As String)
        'Định dạng lại file Excel
        Dim exc As New Excel.Application
        Dim xlWB As Excel.Workbook
        Dim i
        Try
            exc = GetObject(, "excel.application")
            xlWB = exc.Workbooks.Add(fileName)
            exc.Worksheets(Sheet_Name).Select()
            exc.Cells(1, 1) = TenPK
            exc.Cells(2, 1) = "PHÒNG TÀI CHÍNH"
            exc.Cells(1, 6) = "DANH SÁCH THU PHÍ DỊCH VỤ NGOẠI TRÚ"
            Dim khoangtg As String = ""
            If Format(txtNgaykham.Value, "yyMMdd") = Format(txtDen.Value, "yyMMdd") Then
                khoangtg = "Ngày: " + Format(txtNgaykham.Value, "dd/MM/yyyy")
            Else
                khoangtg = "Từ: " + Format(txtNgaykham.Value, "HH:mm dd/MM/yyyy") + " đến: " + Format(txtDen.Value, "HH:mm dd/MM/yyyy")
            End If
            With exc
                .Range("F1", "P1").Merge()
                .Range("F2", "P2").Merge()
                .Cells(1, 6) = "DANH SÁCH THU PHÍ DỊCH VỤ NGOẠI TRÚ"
                .Cells(2, 6) = khoangtg
                .Range("A1", "C1").Merge()
                .Range("A2", "C2").Merge()

                .Range("F1", "P1").Font.Size = 14
                .Range("F1", "P1").Font.Bold = True
                .Rows(4).Orientation = -90
                .Rows(4).font.bold = True
                .Rows(2).font.bold = True
                .Rows("4:4").Select()
                .Selection.RowHeight = 80
                .Rows("2:2").Select()
                .Rows(grdThongkeBN.Rows.Count + 3).RowHeight = 30
                With .Selection
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .WrapText = False
                    .Orientation = 0
                    .AddIndent = False
                    .IndentLevel = 0
                    .ShrinkToFit = False
                End With
                .Rows("1:1").Select()
                .Selection.RowHeight = 29.25
                .ActiveWindow.ScrollColumn = 2
                .ActiveWindow.ScrollColumn = 4
                .ActiveWindow.ScrollColumn = 3
                .ActiveWindow.ScrollColumn = 2
                .ActiveWindow.ScrollColumn = 1
                With .ActiveSheet.PageSetup
                    .PrintTitleRows = ""
                    .PrintTitleColumns = ""
                End With
                .ActiveSheet.PageSetup.PrintArea = ""
                With .ActiveSheet.PageSetup
                    .LeftHeader = ""
                    .CenterHeader = ""
                    .RightHeader = ""
                    .LeftFooter = ""
                    .CenterFooter = ""
                    .RightFooter = ""
                    .LeftMargin = .Application.InchesToPoints(0.25)
                    .RightMargin = .Application.InchesToPoints(0.25)
                    .TopMargin = .Application.InchesToPoints(0.5)
                    .BottomMargin = .Application.InchesToPoints(0.5)
                    .HeaderMargin = .Application.InchesToPoints(0.5)
                    .FooterMargin = .Application.InchesToPoints(0.5)
                    .PrintHeadings = False
                    .PrintGridlines = False
                    .CenterHorizontally = False
                    .CenterVertically = False
                    .Orientation = Excel.XlPageOrientation.xlLandscape
                    .Draft = False
                    .PaperSize = Excel.XlPaperSize.xlPaperA4
                    .BlackAndWhite = False
                    .Zoom = 100
                End With
                .Columns(1).EntireColumn.AutoFit()
                .Columns("F:F").EntireColumn.AutoFit()
                .Columns("G:G").EntireColumn.AutoFit()
                For i = 1 To grdThongkeBN.Cols.Count
                    If grdThongkeBN.Cols(i - 1).Visible = True Then .Columns(i).EntireColumn.AutoFit()
                Next
                .Rows("4:4").Select()
                .ActiveWindow.SmallScroll(Down:=48)
                .Rows("4:" + (grdThongkeBN.Rows.Count + 3).ToString.Trim).Select()
                '.Range("A4:AX" + (grdThongkeBN.Rows.Count + 3).ToString.Trim).Select()
                '.Selection.Borders(Excel.XlLineStyle.xlDiagonalDown).LineStyle = xlNone
                'Selection.Borders(xlDiagonalUp).LineStyle = xlNone
                With .Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                End With
                With .Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                End With
                With .Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                End With
                With .Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                End With
                With .Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                End With
                With .Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                End With
                'tÊN TRƯỞNG BAN
                .Range("B" + (grdThongkeBN.Rows.Count + 5).ToString.Trim).Select()
                .ActiveCell.FormulaR1C1 = "TRƯỞNG BAN TÀI CHÍNH"
                '.Range("B" + (grdThongkeBN.Rows.Count + 9).ToString.Trim).Select()
                '.ActiveCell.FormulaR1C1 = UCase("1// NGÔ VĂN THU")
                'Tên người thu phí
                .Range("R" + (grdThongkeBN.Rows.Count + 5).ToString.Trim).Select()
                .ActiveCell.FormulaR1C1 = "NGƯỜI TỔNG HỢP"
                .Range("R" + (grdThongkeBN.Rows.Count + 9).ToString.Trim).Select()
                .ActiveCell.FormulaR1C1 = UCase(Tendaydu)
                .Range("B" + (grdThongkeBN.Rows.Count + 5).ToString.Trim + ":T" + (grdThongkeBN.Rows.Count + 5).ToString.Trim).Select()
                With .Selection
                    .WrapText = False
                    .Orientation = 0
                    .AddIndent = False
                    .IndentLevel = 0
                    .ShrinkToFit = False
                    .MergeCells = True
                End With
                With .Selection
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignBottom
                    .WrapText = False
                    .Orientation = 0
                    .AddIndent = False
                    .IndentLevel = 0
                    .ShrinkToFit = False
                    .MergeCells = True
                End With
                .Range("B" + (grdThongkeBN.Rows.Count + 9).ToString.Trim + ":T" + (grdThongkeBN.Rows.Count + 9).ToString.Trim).Select()
                With .Selection
                    .WrapText = False
                    .Orientation = 0
                    .AddIndent = False
                    .IndentLevel = 0
                    .ShrinkToFit = False
                    .MergeCells = True
                End With
                With .Selection
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignBottom
                    .WrapText = False
                    .Orientation = 0
                    .AddIndent = False
                    .IndentLevel = 0
                    .ShrinkToFit = False
                    .MergeCells = True
                End With
                .Selection.Font.Bold = True
                .Visible = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdInDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInDS.Click
        ' Get the grid's PrintDocument object.
        Dim pd As Printing.PrintDocument
        pd = grdThongkeBN.PrintParameters.PrintDocument()

        ' Set up the page (landscape, 1.5" left margin).
        With pd.DefaultPageSettings
            .Margins.Top = 50
            .Margins.Bottom = 50
            .PaperSize.RawKind = 9
            .Landscape = True
            .Margins.Left = 20
            .Margins.Right = 20
        End With
        ' Set up the header and footer fonts.

        grdThongkeBN.PrintParameters.HeaderFont = New Font("Times New Roman", 12, FontStyle.Bold)
        grdThongkeBN.PrintParameters.FooterFont = New Font("Arial Narrow", 8, FontStyle.Italic)

        ' Preview the grid.
        Dim khoangtg As String = ""
        If Format(txtNgaykham.Value, "yyMMdd") = Format(txtDen.Value, "yyMMdd") Then
            khoangtg = "Ngày: " + Format(txtNgaykham.Value, "dd/MM/yyyy")
        Else
            khoangtg = "Từ: " + Format(txtNgaykham.Value, "HH:mm dd/MM/yyyy") + " đến: " + Format(txtDen.Value, "HH:mm dd/MM/yyyy")
        End If
        Dim Header_Tit As String = ""
        Header_Tit = "DANH SÁCH THU PHÍ DỊCH VỤ NGOẠI TRÚ               " + khoangtg
        grdThongkeBN.PrintGrid("Báo cáo thu viện phí", C1.Win.C1FlexGrid.PrintGridFlags.FitToPageWidth + C1.Win.C1FlexGrid.PrintGridFlags.ShowPreviewDialog, Header_Tit, Chr(9) + Chr(9) + "Page {0} of {1}")
    End Sub
End Class