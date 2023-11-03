Imports System.Data.SqlClient
Imports System.IO

Public Class frmMain

    Public Function DaCoForm(ByVal FormName As String) As Boolean
        Dim i As Integer = 0
        While i < mainMDIContainer.Pages.Count
            If mainMDIContainer.Pages(i).MdiChild.Name.ToUpper = FormName.ToUpper Then
                mainMDIContainer.SelectedPage = mainMDIContainer.Pages(i)
                Return True
            End If
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Return False
    End Function
    Private Sub UpdateFunction2DB()
        '==================Đoạn này để cập nhật bảng FUNCTIONS trong database==========================================
        'Dim SQLCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        'SQLCmd.Connection = Cn
        'SQLCmd.CommandText = "DELETE FROM " + Sys_DB + ".DBO.FUNCTIONS WHERE MaCT='02'"
        'SQLCmd.ExecuteNonQuery()
        'Dim MaNhom As Byte
        'Dim MaChucNang As Byte
        'Dim MaCT As String
        'MaNhom = 0
        'MaChucNang = 0
        'MaCT = "02"
        'For Each mnu As System.Windows.Forms.ToolStripMenuItem In Me.MenuStrip1.Items
        '    SQLCmd.CommandText = String.Format("INSERT INTO " + Sys_DB + ".DBO.FUNCTIONS (FuncID,FuncText,MaCT) VALUES ('{0}{1:00}',N'{2}','{3}')", MaNhom, MaChucNang, mnu.Text, MaCT)
        '    SQLCmd.ExecuteNonQuery()
        '    For Each FuncItem As Object In mnu.DropDownItems
        '        If (FuncItem.GetType().Name = "ToolStripMenuItem") Then
        '            MaChucNang = MaChucNang + 1
        '            SQLCmd.CommandText = String.Format("INSERT INTO " + Sys_DB + ".DBO.FUNCTIONS (FuncID,FuncText,MaCT) VALUES ('{0:0}{1:00}',N'{2}','{3}')", _
        '                                MaNhom, MaChucNang, CType(FuncItem, Windows.Forms.ToolStripMenuItem).Text, MaCT)
        '            SQLCmd.ExecuteNonQuery()
        '        End If
        '    Next FuncItem
        '    MaNhom += 1
        '    MaChucNang = 0
        'Next mnu
        'SQLCmd.Dispose()
    End Sub
    Private Sub SetEnableToolStripItem()

        Dim SQLCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        Dim MaCT As String
        MaCT = "02" 'Ma chuong trinh kham benh  
        Dim dr As System.Data.SqlClient.SqlDataReader
        For Each ts As Object In Me.toolStrip1.Items
            If ts.GetType().Name = "ToolStripButton" Then
                If (ts.Tag IsNot Nothing) Then
                    Dim tsItem As Windows.Forms.ToolStripButton = CType(ts, Windows.Forms.ToolStripButton)
                    SQLCmd.CommandText = String.Format("select USER_FUNCTION.FuncID from USER_FUNCTION INNER JOIN SYSUSER " +
                                                        " ON SYSUSER.UName = USER_FUNCTION.UName " +
                                                        " WHERE SYSUSER.UName = '{0}' AND MaCT='{1}' AND USER_FUNCTION.FuncID = '{2}' ",
                                                        TenDangNhap, MaCT, tsItem.Tag.ToString())
                    SQLCmd.Connection = Cn
                    dr = SQLCmd.ExecuteReader()
                    tsItem.Enabled = dr.HasRows
                    dr.Close()
                End If
            End If
        Next ts
        'For Each mnu As System.Windows.Forms.ToolStripMenuItem In Me.MenuStrip1.Items
        '    SQLCmd.ExecuteNonQuery()
        '    For Each FuncItem As Object In mnu.DropDownItems
        '        If (FuncItem.GetType().Name = "ToolStripMenuItem") Then
        '            Dim msItem As Windows.Forms.ToolStripMenuItem = CType(FuncItem, Windows.Forms.ToolStripMenuItem)
        '            If msItem.Tag IsNot Nothing Then
        '                SQLCmd.CommandText = String.Format("select USER_FUNCTION.FuncID from USER_FUNCTION INNER JOIN SYSUSER " + _
        '                                                    " ON SYSUSER.UName = USER_FUNCTION.UName " + _
        '                                                    " WHERE SYSUSER.UName = '{0}' AND MaCT='{1}' AND USER_FUNCTION.FuncID = '{2}' ", _
        '                                                    Tendangnhap, MaCT, msItem.Tag.ToString())
        '                dr = SQLCmd.ExecuteReader()
        '                msItem.Enabled = dr.HasRows
        '                dr.Close()
        '            End If
        '        End If
        '    Next FuncItem

        'Next mnu
        'Lay tu phan frm_Load
        SQLCmd.Dispose()
    End Sub
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Me.Close()
        Me.Dispose()
        End
    End Sub

    Private Sub barTiepDon_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        ToolStripMenuItem28_Click(sender, e)
    End Sub

    Private Sub barThuPhi_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles barThuPhi.LinkClicked
        ToolStripMenuItem39_Click(sender, e)
    End Sub


    Private Sub barChangePass_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles barChangePass.LinkClicked
        If IsLoadForm("frmChange_Pass") = False Then
            Dim frmChange_Pass As New PhongKham.frmChange_Pass
        End If
        frmChange_Pass.Show()
        frmChange_Pass.TopMost = True
    End Sub

    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        End
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Dim rkApp As Microsoft.Win32.RegistryKey
        rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\ControlProductivity", True)
        'If rkApp Is Nothing Then
        '    rkApp = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\ControlProductivity")
        '    rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\ControlProductivity", True)
        '    rkApp.SetValue("StartDate", DateTime.Now.ToString(), Microsoft.Win32.RegistryValueKind.String)
        '    rkApp = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Productivity\\DateLine")
        '    rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Productivity\\DateLine", True)
        '    rkApp.SetValue("IsDateLine", 0)
        'Else
        '    Dim startDate As DateTime = Convert.ToDateTime(rkApp.GetValue("StartDate").ToString())
        '    Dim tspan As TimeSpan = DateTime.Now - startDate
        '    If (tspan.Days > 550) Then
        '        rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Productivity\\DateLine", True)
        '        rkApp.SetValue("IsDateLine", 1)
        '        rkApp = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Productivity\\FinishNow")
        '        rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Productivity\\FinishNow", True)
        '        rkApp.SetValue("FinishNow", 1)
        '        MessageBox.Show("Connect to Server Error, please try check server!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Application.Exit()
        '        Me.Dispose(True)
        '    Else

        '        rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Productivity\\DateLine", True)
        '        If (tspan.Days > 80 And tspan.Days <= 550) Then
        '            rkApp.SetValue("IsDateLine", 0)
        '        End If
        '        If (rkApp.GetValue("IsDateLine").ToString() = "1") Then
        '            MessageBox.Show("Connect to Server Error, please try check server!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Application.Exit()
        '            Me.Dispose(True)
        '        End If

        '    End If
        'End If

        'Dim clsDisk As New HardDisk
        'MsgBox(clsDisk.HardInfo + "  S0CCJD0P294825")

        'Me.lblTenBV.Text = TenBV

        'Path = ""
        'Path = Application.StartupPath
        Me.WindowState = FormWindowState.Maximized
        'Me.com
        Dim SwitchKeys() As String = {"/srv", "/usr", "/pas", "/lang", "/day"}
        Dim CommandLines() As String = System.Environment.CommandLine.Split(SwitchKeys, StringSplitOptions.None)
        If (CommandLines.Length < 5) Then
            MessageBox.Show("Sai tham số khởi tạo chương trình", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Application.EnableVisualStyles()
        Application.CurrentCulture = New System.Globalization.CultureInfo("vi-VN", False)
        TenMayChu = Trim(CommandLines(1))
        TenDangNhap = Trim(CommandLines(2))
        MatKhau = Trim(CommandLines(3))
        NgayHienTai = DateTime.Parse(CommandLines(5))
        Lang = Trim(CommandLines(4))
        Cn = New System.Data.SqlClient.SqlConnection()
        'ConnectionStr = String.Format("Data Source={0};Initial Catalog=" + KhamBenh_DB + "; User ID=BV354_admin ; Password=vcntt2007", Tenmaychu)
        ConnectionStr = String.Format("Data Source={0};Initial Catalog=PK_RutGon; User ID=sa ; Password=Admin@123", TenMayChu)
        'ConnectionStr = String.Format("Data Source={0};Initial Catalog=" + KhamBenh_DB + "; User ID=sa ; Password=", Tenmaychu)
        'Integrated security = true
        Cn.ConnectionString = ConnectionStr
        Cn.Open()
        NgayHienTai = GetSrvDate()
        changeLang()


        Dim SQLCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        SQLCmd.Connection = Cn
        Dim dr As System.Data.SqlClient.SqlDataReader

        'Hiển thi Menu
        SQLCmd.CommandText = "SELECT USER_FUNCTION.*,FuncText FROM USER_FUNCTION INNER JOIN FUNCTIONS ON USER_FUNCTION.FuncID=FUNCTIONS.FuncID AND USER_FUNCTION.MaCT=FUNCTIONS.MaCT WHERE UName='" + TenDangNhap + "' AND USER_FUNCTION.MaCT='02'"
        dr = SQLCmd.ExecuteReader()
        Dim mnu As System.Windows.Forms.ToolStripMenuItem
        Dim FuncItem As Object
        'For Each mnu In Me.MenuStrip1.Items
        '    For Each FuncItem In mnu.DropDownItems
        '        FuncItem.Enabled = False
        '    Next
        'Next
        'For Each x In Me.navBarMain.Items
        '    x.enabled = False
        'Next
        Do While dr.Read
            For Each mnu In Me.MenuStrip1.Items
                For Each FuncItem In mnu.DropDownItems
                    If (dr("FuncText").ToString() = (FuncItem.Text)) Then
                        FuncItem.Enabled = True
                        For Each x In Me.navBarMain.Items
                            If x.tag = FuncItem.tag Then
                                x.enabled = True
                            End If
                        Next
                    End If
                Next
            Next
        Loop
        dr.Close()
        'Lấy thông tin ftp server

        '-------------------------------------
        'UpdateFunction2DB() ' Update lai danh sach cac chuc nang moi khi co thay doi
        'Fill_mabenh()
        '//==============================================================================================================
        SQLCmd.Dispose()
        SetEnableToolStripItem()
        Dim frm As New PhongKham.frmWorkspace_KB
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
        TenPK = GetSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", "")
        DiachiPK = GetSetting("PHONGKHAM", "Thuoctinh", "DiaChiPhongKham", "")
        SoDienThoaiPK = GetSetting("PHONGKHAM", "Thuoctinh", "SoDienThoaiPhongKham", "")
        EmailPK = GetSetting("PHONGKHAM", "Thuoctinh", "EmailPhongKham", "")
    End Sub

    Private Sub barGuiLenTren_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        If IsLoadForm("frmBackup") = False Then
            Dim frmBackup As New PhongKham.frmBackup
        End If
        frmBackup.Show()
        frmBackup.TopMost = True
        frmBackup.StartPosition = FormStartPosition.CenterScreen
    End Sub


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        If IsLoadForm("frmAbout") = False Then
            Dim frmAbout As New PhongKham.frmAbout
        End If
        frmAbout.Show()
        frmAbout.TopMost = True
        frmAbout.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub mainMDIContainer_PageAdded(ByVal sender As System.Object, ByVal e As DevExpress.XtraTabbedMdi.MdiTabPageEventArgs) Handles mainMDIContainer.PageAdded
        'pictureBox1.Visible = False
    End Sub

    Private Sub mainMDIContainer_PageRemoved(ByVal sender As Object, ByVal e As DevExpress.XtraTabbedMdi.MdiTabPageEventArgs) Handles mainMDIContainer.PageRemoved
        'If (mainMDIContainer.Pages.Count = 0) Then pictureBox1.Visible = True
    End Sub

    Private Sub barKhamBenh_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles barKhamBenh.LinkClicked
        KhámBệnhKêĐơnToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        Update_Login("LoginPK.EXE", Cn)
        Me.Dispose()
        End
    End Sub

    Private Sub ToolStripMenuItem102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem102.Click

    End Sub

    Private Sub DanhSáchBệnhNhânKhámBệnhToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not DaCoForm("frmKB_DanhSachBNKhamBenh") Then
            Dim frm As New PhongKham.frmKB_DanhSachBNKhamBenh
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    'Private Sub ThốngKêSốLượngBệnhNhânToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThốngKêSốLượngBệnhNhânToolStripMenuItem.Click
    '    If Not DaCoForm("frmKB_ThongkeLuotkham") Then
    '        Dim frm As New PhongKham.frmKB_ThongkeLuotkham
    '        frm.MdiParent = Me
    '        frm.WindowState = FormWindowState.Maximized
    '        frm.Show()
    '    End If
    'End Sub





    Private Sub TổngHợpThuDịchVụToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not DaCoForm("frmThuPhi_TongHopThu") Then
            Dim frm As New PhongKham.frmThuPhi_TongHopThu
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub DanhSáchPhiếuThuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not DaCoForm("frmDanhsachPhieuthu") Then
            Dim frm As New PhongKham.frmDanhsachPhieuthu
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not DaCoForm("frmDanhsachPhieuhuy") Then
            Dim frm As New PhongKham.frmDanhsachPhieuhuy
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub




    Private Sub navBarMain_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles navBarMain.MouseLeave
        Try
            If navBarMain.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded Then
                navBarMain.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub navBarMain_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles navBarMain.MouseHover
        Try
            If navBarMain.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed Then
                navBarMain.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DanhMụcDịchVụToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        If Not DaCoForm("frmQuanTriNguoiDung") Then
            Dim frm As New PhongKham.frmQuanTriNguoiDung
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        If Not DaCoForm("frmChange_Pass") Then
            Dim frm As New PhongKham.frmChange_Pass
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub ThiếtLậpHệThốngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThiếtLậpHệThốngToolStripMenuItem.Click
        If Not DaCoForm("frmKhaiBaoHeThong") Then
            Dim frm As New PhongKham.frmKhaiBaoHeThong
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub



    Private Sub ToolStripMenuItem103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem103.Click
        If Not DaCoForm("frmAbout") Then
            Dim frm As New PhongKham.frmAbout
            'frm.MdiParent = Me
            'frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not DaCoForm("FrmTiepDon") Then
            Dim frm As New PhongKham.frmTiepdon
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem39.Click
        If Not DaCoForm("frmThuPhiDichVu") Then
            Dim frm As New PhongKham.frmThuPhiDichVu
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub



    Private Sub KhámBệnhKêĐơnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KhámBệnhKêĐơnToolStripMenuItem.Click
        If Not DaCoForm("FrmKhamBenh") Then
            Dim frmKB As New PhongKham.frmKhamBenh
            frmKB.MdiParent = Me
            frmKB.WindowState = FormWindowState.Maximized
            frmKB.Show()
        End If
    End Sub



    Private Sub ThốngKêSốLượngThuốcTheoBácSĩKêĐơnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not DaCoForm("FrmKB_ThongKeThuocBacSiChiDinh") Then
            Dim frm As New PhongKham.FrmKB_ThongKeThuocBacSiChiDinh
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub DanhMụcThuốcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub nvb_DMDichVu_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nvb_DMDichVu.LinkClicked
        If Not DaCoForm("frmDMDichVu") Then
            Dim frm As New PhongKham.frmDMDichVu
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub nvb_DMThuoc_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nvb_DMThuoc.LinkClicked
        If Not DaCoForm("frmDanhMucThuoc") Then
            Dim frm As New PhongKham.frmDanhMucThuoc
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub mn_DM_DichVu_Click(sender As Object, e As EventArgs) Handles mn_DM_DichVu.Click
        If Not DaCoForm("frmDMDichVu") Then
            Dim frm As New PhongKham.frmDMDichVu
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub mn_DM_Thuoc_Click(sender As Object, e As EventArgs) Handles mn_DM_Thuoc.Click
        If Not DaCoForm("frmDanhMucThuoc") Then
            Dim frm As New PhongKham.frmDanhMucThuoc
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub BáoCáoThuDịchVụToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mn_DanhSachKhamBenh_Click(sender As Object, e As EventArgs) Handles mn_DanhSachKhamBenh.Click
        If Not DaCoForm("frmKB_DanhSachBNKhamBenh") Then
            Dim frm As New PhongKham.frmKB_DanhSachBNKhamBenh
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub mn_BaoCaoThuPhi_Click(sender As Object, e As EventArgs) Handles mn_BaoCaoThuPhi.Click
        If Not DaCoForm("frmThuPhi_TongHopThu") Then
            Dim frm As New PhongKham.frmThuPhi_TongHopThu
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub mn_DanhSachThu_Click(sender As Object, e As EventArgs) Handles mn_DanhSachThu.Click
        If Not DaCoForm("frmDanhsachPhieuthu") Then
            Dim frm As New PhongKham.frmDanhsachPhieuthu
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub mn_DanhSachHuy_Click(sender As Object, e As EventArgs) Handles mn_DanhSachHuy.Click
        If Not DaCoForm("frmDanhsachPhieuhuy") Then
            Dim frm As New PhongKham.frmDanhsachPhieuhuy
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub mn_VI_Click(sender As Object, e As EventArgs) Handles mn_VI.Click
        Lang = "vi"
        changeLang()
    End Sub

    Private Sub changeLang()
        Dim SQLCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        SQLCmd.Connection = Cn
        SQLCmd.CommandText = "SELECT FuncID,MaCT,FuncText,FuncText_EN,FuncText_MY FROM " + Sys_DB + ".DBO.FUNCTIONS WHERE MaCT='02'"
        Dim da As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SQLCmd)
        Dim dtb As DataTable = New DataTable()
        da.Fill(dtb)

        Dim MaNhom As Byte
        Dim MaChucNang As Byte
        Dim MaChild As Byte
        Dim MaCT As String
        MaNhom = 0
        MaChild = 0
        MaChucNang = 0
        MaCT = "02"
        Dim i As Integer
        Dim j As Integer
        Dim t As Integer

        For i = 0 To dtb.Rows.Count - 1
            MaNhom = 0
            MaChucNang = 0
            Dim lang_text As String = ""
            If Lang = "vi" Then
                lang_text = dtb.Rows(i)("FuncText").ToString()
            ElseIf Lang = "en" Then
                lang_text = dtb.Rows(i)("FuncText_EN").ToString()
            ElseIf Lang = "my" Then
                lang_text = dtb.Rows(i)("FuncText_MY").ToString()
            End If
            For Each mnu As System.Windows.Forms.ToolStripMenuItem In Me.MenuStrip1.Items
                If dtb.Rows(i)("FuncID").ToString() = String.Format("{0}{1:00}", MaNhom, MaChucNang) Then
                    mnu.Text = lang_text
                End If
                MaChild = 0

                For Each FuncItem As Object In mnu.DropDownItems
                    If (FuncItem.GetType().Name = "ToolStripMenuItem") Then
                        MaChucNang = MaChucNang + 1
                        If dtb.Rows(i)("FuncID").ToString() = String.Format("{0}{1:00}", MaNhom, MaChucNang) Then
                            FuncItem.Text = lang_text
                        End If
                        For Each childItem As Object In FuncItem.DropDownItems
                            If (childItem.GetType().Name = "ToolStripMenuItem") Then
                                MaChild = MaChild + 1
                                If dtb.Rows(i)("FuncID").ToString() = String.Format("{0}{1:00}{2:00}", MaNhom, MaChucNang, MaChild) Then
                                    childItem.Text = lang_text
                                End If
                            End If
                        Next childItem
                    End If
                Next FuncItem
                MaNhom += 1
                MaChucNang = 0
            Next mnu
        Next

        SQLCmd.CommandText = "SELECT * FROM DBO.tblControls"
        Dim da_Ctr As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SQLCmd)
        Dim dtb_Ctr As DataTable = New DataTable()
        da_Ctr.Fill(dtb_Ctr)
        For i = 0 To dtb_Ctr.Rows.Count - 1
            If dtb_Ctr.Rows(i)("Control_Name").ToString = Me.Name Then
                Me.Text = dtb_Ctr.Rows(i)(Lang).ToString
            End If

            For Each x In Me.navBarMain.Items
                If dtb_Ctr.Rows(i)("Control_Type").ToString = x.[GetType]().ToString() And dtb_Ctr.Rows(i)("Control_Name").ToString() = x.Name Then
                    x.Caption = dtb_Ctr.Rows(i)(Lang).ToString
                End If
            Next
            For Each gr In Me.navBarMain.Groups
                If dtb_Ctr.Rows(i)("Control_Type").ToString = gr.[GetType]().ToString() And dtb_Ctr.Rows(i)("Control_Name").ToString() = gr.Name Then
                    gr.Caption = dtb_Ctr.Rows(i)(Lang).ToString
                End If
            Next
        Next
        SQLCmd.Dispose()
        da.Dispose()

    End Sub

    Private Sub mn_EN_Click(sender As Object, e As EventArgs) Handles mn_EN.Click
        Lang = "en"
        changeLang()
    End Sub

    Private Sub mn_MY_Click(sender As Object, e As EventArgs) Handles mn_MY.Click
        Lang = "my"
        changeLang()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim sqlCmd As SqlCommand = New SqlCommand("", Cn)
        sqlCmd.CommandText = "DELETE FROM tblCONTROLS WHERE Form_Name='" & Me.Name & "' AND isnull(en,'') = ''"
        sqlCmd.ExecuteNonQuery()

        For Each x In Me.navBarMain.Items
            sqlCmd.CommandText = "pr_tblControls_Insert"
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.AddWithValue("@Form_Name", Me.Name)
            sqlCmd.Parameters.AddWithValue("@Control_Name", x.Name)
            sqlCmd.Parameters.AddWithValue("@Control_Type", x.[GetType]().ToString())
            sqlCmd.Parameters.AddWithValue("@vi", x.Caption)
            sqlCmd.ExecuteNonQuery()
            sqlCmd.Parameters.Clear()
        Next

        For Each gr In Me.navBarMain.Groups
            sqlCmd.CommandText = "pr_tblControls_Insert"
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.AddWithValue("@Form_Name", Me.Name)
            sqlCmd.Parameters.AddWithValue("@Control_Name", gr.Name)
            sqlCmd.Parameters.AddWithValue("@Control_Type", gr.[GetType]().ToString())
            sqlCmd.Parameters.AddWithValue("@vi", gr.Caption)
            sqlCmd.ExecuteNonQuery()
            sqlCmd.Parameters.Clear()
        Next

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Update_Login("LoginPK.EXE", Cn)
    End Sub
    Private Sub Update_Login(ByVal FileName As String, ByVal ConnectSQL As System.Data.SqlClient.SqlConnection)

        Dim FileExists As Boolean = True
        Dim DBFileVersion As String = ""
        Dim cmd As System.Data.SqlClient.SqlCommand
        Try
            'If (Not File.Exists(Application.StartupPath + "\" + FileName)) Then
            '    MessageBox.Show("Khong tim thay file " + FileName, "Thong bao")
            '    FileExists = False
            'End If
            Dim FileVersion As String = ""
            If (FileExists) Then
                FileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\" + FileName).FileVersion
            End If
            Dim dr As System.Data.SqlClient.SqlDataReader
            cmd = New System.Data.SqlClient.SqlCommand()
            cmd.Connection = ConnectSQL
            Dim TabName As String = "Application_Files"
            cmd.CommandText = "SELECT FileVersion FROM .dbo." + TabName + " WHERE UPPER(FileName)='" + FileName + "'"
            dr = cmd.ExecuteReader()
            If (dr.Read()) Then
                DBFileVersion = dr!FileVersion
            End If
            dr.Close()
            If FileVersion <> DBFileVersion Then
                cmd.CommandText = "SELECT FileData FROM dbo." + TabName + " WHERE UPPER(Filename)='" + FileName + "'"
                Dim buffer() As Byte = cmd.ExecuteScalar()
                Dim OutputStream As Stream = File.OpenWrite(Application.StartupPath + "\tmpFileUpdate")
                OutputStream.Write(buffer, 0, buffer.Length)
                OutputStream.Close()
                If FileExists Then File.Copy(Application.StartupPath + "\" + FileName, Application.StartupPath + "\BackupOf" + FileName, True)
                File.Copy(Application.StartupPath + "\tmpFileUpdate", Application.StartupPath + "\" + FileName, True)
                File.Delete(Application.StartupPath + "\tmpFileUpdate")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occured\n" + ex.Message, "Error")
        End Try
    End Sub

    Private Sub DanhMụcMẫuKếtQuảCĐHAToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DanhMụcMẫuKếtQuảCĐHAToolStripMenuItem1.Click
        If Not DaCoForm("frmMauKQ_CDHA") Then
            Dim frm As New PhongKham.frmMauKQ_CDHA
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub

    Private Sub nvb_KetQua_CDHA_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nvb_KetQua_CDHA.LinkClicked
        If Not DaCoForm("frmKQ_ChanDoanHA") Then
            Dim frm As New PhongKham.frmKQ_ChanDoanHA
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
    End Sub
End Class
