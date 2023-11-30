Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.IO
Imports C1.Win.C1FlexGrid
Imports Camera_NET
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DirectShowLib

Public Class uct_KetQua_CDHA
    Public sMaKhamBenh As String = ""
    Public sTenBenhNhan As String = ""
    Private Sub Set_pos_start()
        Try
            With panDS_mauKQ
                '.Top = 27
                '.Left = 4
                .Visible = False
            End With

            'txtNgay.Value = GetSrvDate()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub load_chidinh()
        Dim SQL_DaTH As String
        Dim SQL_ChuaTH As String
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim temp_DaTH = ""
        Dim temp_ChuaTH1 = ""
        Dim temp_ChuaTH2 = ""
        ' & " inner join  viewPHIEUTHANHTOAN_CT k on a.Makhambenh = k.Makhambenh and b.Madichvu = k.Madichvu " _
        Try

            SQL_ChuaTH = "select  a.MaphieuCD," _
                & " b.MaDichvu As MaDichVu, f.TenDichvu As TenDichVu from DBO.tblKhambenh_Chidinh a " _
                & " left outer join DBO.tblKhambenh_Dichvu b on a.MaphieuCD = b.MaphieuCD" _
                & " left outer join .DBO.DMDICHVU f on b.madichvu = f.madichvu WHERE a.MaKhamBenh = '" & sMaKhamBenh & "'"
            Cmd = New SqlCommand(SQL_ChuaTH, Cn)
            da = New SqlDataAdapter(Cmd)
            Dim dtb As New DataTable
            da.Fill(dtb)
            grd_ChiDinh.DataSource = dtb
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Load_DSMau(ByVal TenBS As String, ByVal Khuvuc As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Try
            grdDS_mauKQ.Rows.Count = 0
            grdDS_mauKQ.Redraw = False
            SQL = "Select [ID] ,[Nhom]  ,[Tenmau] ,[Dungchung] ,[Khuvuc] from DMCDHA_MAUKQ  " 'where Khuvuc = N'" & Khuvuc & "' order by nhom "
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            Do While Dr.Read()
                grdDS_mauKQ.AddItem(Dr!nhom & vbTab & Dr!tenmau & vbTab & Dr!Khuvuc)
            Loop
            Dr.Close()
            grdDS_mauKQ.Tree.Column = 1
            grdDS_mauKQ.Cols(0).Visible = False
            'grdDS.Subtotal(AggregateEnum.None, 0, 1, "{0}")
            grdDS_mauKQ.Subtotal(AggregateEnum.None, 0, 0, 1, "{0}")
            For i = 0 To grdDS_mauKQ.Rows.Count - 1
                If grdDS_mauKQ.Rows(i).IsNode Then grdDS_mauKQ.Rows(i).Node.Collapsed() = True
            Next
            grdDS_mauKQ.Redraw = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub comboBoxResolutionList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxResolutionList.SelectedIndexChanged
        If (Not cameraControl.CameraCreated) Then
            Exit Sub
        End If

        Dim comboBoxResolutionIndex = comboBoxResolutionList.SelectedIndex
        If (comboBoxResolutionIndex < 0) Then
            Exit Sub
        End If
        Dim resolutions As ResolutionList = Camera.GetResolutionList(cameraControl.Moniker)

        'If (resolutions Is Nullable) Then
        '    Exit Sub
        'End If
        If (comboBoxResolutionIndex >= resolutions.Count) Then
            Exit Sub
        End If

        If (0 = resolutions(comboBoxResolutionIndex).CompareTo(cameraControl.Resolution)) Then
            'this resolution Is already selected
            Exit Sub
        End If

        'Recreate camera
        SetCamera(cameraControl.Moniker, resolutions(comboBoxResolutionIndex))
    End Sub

    Private Sub comboBoxCameraList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxCameraList.SelectedIndexChanged
        If comboBoxCameraList.SelectedIndex < 0 Then
            cameraControl.CloseCamera()
        Else
            SetCamera(_CameraChoice.Devices(comboBoxCameraList.SelectedIndex).Mon, Nothing)
        End If

        FillResolutionList()
    End Sub
    Private Sub SetCamera(ByVal camera_moniker As Runtime.InteropServices.ComTypes.IMoniker, ByVal resolution As Resolution)

        Try
            cameraControl.SetCamera(camera_moniker, resolution)
        Catch e As Exception
            MessageBox.Show(e.Message, "Error while running camera")
        End Try

        If Not cameraControl.CameraCreated Then Return
        cameraControl.MixerEnabled = True
        UpdateCameraBitmap()
        UpdateGUIButtons()
    End Sub
    Private Sub UpdateUnzoomButton()
        If _bZoomed Then
            buttonUnZoom.Left = cameraControl.Left + (cameraControl.ClientRectangle.Width - cameraControl.OutputVideoSize.Width) / 2 + 4
            buttonUnZoom.Top = cameraControl.Top + (cameraControl.ClientRectangle.Height - cameraControl.OutputVideoSize.Height) / 2 + 40
            buttonUnZoom.Visible = True
        Else
            buttonUnZoom.Visible = False
        End If
    End Sub
    'Generate bitmap for overlay
    Private Sub UpdateCameraBitmap()

        If (Not cameraControl.MixerEnabled) Then
            Exit Sub
        End If

        cameraControl.OverlayBitmap = GenerateColorKeyBitmap(False)

        '#region D3D bitmap mixer
        'if (cameraControl.UseGDI)
        '{
        '    cameraControl.OverlayBitmap = GenerateColorKeyBitmap(false);
        '}
        'else
        '{
        '    cameraControl.OverlayBitmap = GenerateAlphaBitmap();
        '}
        '#endregion
    End Sub

    ''Update buttons of GUI based on Camera state
    Private Sub UpdateGUIButtons()
        ' buttonCrossbarSettings.Enabled = (cameraControl.CrossbarAvailable)
    End Sub
    Private Function GenerateColorKeyBitmap(ByVal useAntiAlias As Boolean) As Bitmap
        Dim w As Integer = cameraControl.OutputVideoSize.Width
        Dim h As Integer = cameraControl.OutputVideoSize.Height
        If w <= 0 OrElse h <= 0 Then Return Nothing
        Dim bmp As Bitmap = New Bitmap(w, h, PixelFormat.Format24bppRgb)
        Dim g As Graphics = Graphics.FromImage(bmp)

        If useAntiAlias Then
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = TextRenderingHint.AntiAlias
        Else
            g.SmoothingMode = SmoothingMode.None
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit
        End If

        g.Clear(cameraControl.GDIColorKey)

        If _bDrawMouseSelection And IsMouseSelectionRectCorrect() Then
            Dim color_of_pen As Color = Color.Gray

            If IsMouseSelectionRectCorrectAndGood() Then
                color_of_pen = Color.Green
            End If

            Dim pen As Pen = New Pen(color_of_pen, 2.0F)
            Dim rect As Rectangle = New Rectangle(CInt((_MouseSelectionRect.left * w)), CInt((_MouseSelectionRect.top * h)), CInt(((_MouseSelectionRect.right - _MouseSelectionRect.left) * w)), CInt(((_MouseSelectionRect.bottom - _MouseSelectionRect.top) * h)))
            g.DrawLine(pen, rect.Left - 5, rect.Top, rect.Right + 5, rect.Top)
            g.DrawLine(pen, rect.Left - 5, rect.Bottom, rect.Right + 5, rect.Bottom)
            g.DrawLine(pen, rect.Left, rect.Top - 5, rect.Left, rect.Bottom + 5)
            g.DrawLine(pen, rect.Right, rect.Top - 5, rect.Right, rect.Bottom + 5)
            pen.Dispose()
        End If

        If _bZoomed Then
            Dim font As Font = New Font("Tahoma", 16)
            Dim textColorKeyed As Brush = New SolidBrush(Color.DarkBlue)
            g.DrawString("Zoom: " & Math.Round(_fZoomValue, 1).ToString("0.0") & "x", font, textColorKeyed, 4, 4)
            font.Dispose()
            textColorKeyed.Dispose()
        End If

        g.Dispose()
        Return bmp
    End Function
    Dim _MouseSelectionRect As NormalizedRect = New NormalizedRect(0, 0, 0, 0)
    Dim _bDrawMouseSelection As Boolean = False
    Private Function IsMouseSelectionRectCorrect() As Boolean
        If Math.Abs(_MouseSelectionRect.right - _MouseSelectionRect.left) < Single.Epsilon * 10 OrElse Math.Abs(_MouseSelectionRect.bottom - _MouseSelectionRect.top) < Single.Epsilon * 10 Then
            Return False
        End If

        If _MouseSelectionRect.left >= _MouseSelectionRect.right OrElse _MouseSelectionRect.top >= _MouseSelectionRect.bottom Then
            Return False
        End If

        If _MouseSelectionRect.left < 0 OrElse _MouseSelectionRect.top < 0 OrElse _MouseSelectionRect.right > 1.0 OrElse _MouseSelectionRect.bottom > 1.0 Then
            Return False
        End If

        Return True
    End Function

    Private Function IsMouseSelectionRectCorrectAndGood() As Boolean
        If Not IsMouseSelectionRectCorrect() Then
            Return False
        End If

        If Math.Abs(_MouseSelectionRect.right - _MouseSelectionRect.left) < 0.1F OrElse Math.Abs(_MouseSelectionRect.bottom - _MouseSelectionRect.top) < 0.1F Then
            Return False
        End If

        Return True
    End Function

    Private Sub buttonClearSnapshotFrame_Click(sender As Object, e As EventArgs) Handles buttonClearSnapshotFrame.Click
        Dim sMaCLS As String = grv_DichVu.GetFocusedRowCellValue("MaDichVu").ToString()
        'Dim sMaPhieuCD As String = grv_DichVu.GetFocusedRowCellValue("MaPhieuCD").ToString()
        'Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
        sTenBenhNhan = TenABC(sTenBenhNhan)
        For i = 0 To ListView1.Items.Count - 1
            Dim strPath = "D:\KetQua_CDHA\" + sMaKhamBenh + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + (i + 1).ToString() + ".jpg" 'Path + "\" + txtSophieuCD.Text + "_" + grv_YeuCau.GetFocusedRowCellValue("MaCDHA").ToString() + "_" + ImageList1.Images.Count.ToString() + ".jpg"
            If System.IO.File.Exists(strPath) Then File.Delete(strPath)
        Next
        ListView1.Clear()
        ImageList1.Images.Clear()
    End Sub

    Private Sub buttonSnapshotNextSourceFrame_Click(sender As Object, e As EventArgs) Handles buttonSnapshotNextSourceFrame.Click
        If Not cameraControl.CameraCreated Then Return
        Dim bitmap As Bitmap = Nothing

        Try
            bitmap = cameraControl.SnapshotOutputImage() '; cameraControl.SnapshotSourceImage()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error while getting a snapshot")
        End Try

        If bitmap Is Nothing Then Return

        'If (bitmap.Width = 720) Then
        '    Dim _selection As Rectangle
        '    _selection = New Rectangle(New Point(170, 40), New Size())
        '    _selection.Width = 525
        '    _selection.Height = 410
        '    Dim crop As Bitmap = bitmap.Clone(_selection, bitmap.PixelFormat)

        '    ImageList1.Images.Add(crop)
        'Else
        ImageList1.Images.Add(bitmap)
        'End If


        Dim sMaCLS As String = grv_DichVu.GetFocusedRowCellValue("MaDichVu").ToString()
        'Dim sMaPhieuCD As String = grv_DichVu.GetFocusedRowCellValue("MaPhieuCD").ToString()
        'sMaCLS = grdYC_CLS.GetData(grdYC_CLS.RowSel, 0)
        Dim ivt As ListViewItem = New ListViewItem()
        ivt.ImageIndex = ImageList1.Images.Count - 1
        ListView1.Items.Add(ivt)
        ListView1.Refresh()
        'Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
        sTenBenhNhan = TenABC(sTenBenhNhan)
        Dim strPath = "D:\KetQua_CDHA\" + sMaKhamBenh + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + ImageList1.Images.Count.ToString() + ".jpg" 'Path + "\" + txtSophieuCD.Text + "_" + grv_YeuCau.GetFocusedRowCellValue("MaCDHA").ToString() + "_" + ImageList1.Images.Count.ToString() + ".jpg"
        If System.IO.File.Exists(strPath) Then File.Delete(strPath)
        If Not System.IO.Directory.Exists("D:\KetQua_CDHA\" + sMaKhamBenh) Then
            System.IO.Directory.CreateDirectory("D:\KetQua_CDHA\" + sMaKhamBenh)
        End If
        bitmap.Save(strPath)

        '' Code Cut anh
    End Sub

    Private Sub uct_KetQua_CDHA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        uct_Load()
    End Sub
    Public Sub uct_Load()
        Set_pos_start()
        Load_DSMau(TenDangNhap, "SA")
        DockPanel2.Enabled = False
        DockPanel3.Enabled = False
        grd_ChiDinh.Enabled = True
        load_chidinh()
    End Sub

    Private Sub lblChonmauKQ_Click(sender As Object, e As EventArgs) Handles lblChonmauKQ.Click
        panDS_mauKQ.Visible = True
        panDS_mauKQ.BringToFront()

        For Each prc As Process In Process.GetProcessesByName("WINWORD")
            prc.Kill()
        Next
    End Sub

    Private Sub grdDS_mauKQ_Click(sender As Object, e As EventArgs) Handles grdDS_mauKQ.Click

    End Sub
    Private Sub Fill_Mau(ByVal BS As String, ByVal Nhom As String, ByVal Ten As String, ByVal Khuvuc As String)
        Dim Temp As Byte()
        Try
            Cmd = New SqlCommand("", Cn)
            Cmd.CommandText = String.Format("SELECT Nhom, Tenmau, isnull(FileData,'') as FileData FROM DMCDHA_MAUKQ WHERE  Nhom = {1} and Tenmau = {2}  and Khuvuc = {3} ", "N'" + BS.Replace("'", "''") + "'", "N'" + Nhom.Replace("'", "''") + "'", "N'" + Ten.Replace("'", "''") + "'", "N'" + Khuvuc.Replace("'", "''") + "'")
            dr = Cmd.ExecuteReader()
            While dr.Read()
                Temp = dr("FileData")
            End While
            'objWinWordControl.CloseControl()
            'LoadFile(Temp)
            Dim memoryStream As New MemoryStream(Temp)
            RichEditControl1.LoadDocument(memoryStream, DocumentFormat.OpenXml)

            dr.Close()
            'WinWordControl.WinWordControl.wd = Nothing
            'WinWordControl.WinWordControl.wordWnd = 0
            'objWinWordControl.LoadDocument(file_mau)
            'objWinWordControl.document.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
            dr.Close()
        End Try
    End Sub
    Private Sub Fill_DataHC2Word()
        Try

            RichEditControl1.Document.BeginUpdate()

            Dim searchResult As ISearchResult = RichEditControl1.Document.StartSearch("<TENPK>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, TenPK.ToUpper)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<DiaChiPK>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, DiachiPK)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Sodt>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, SoDT)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Họ tên đầy đủ của bệnh nhân>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, "")
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Nam/Nữ>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, "")
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Đối tượng>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, "")
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Tuổi>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, "")
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Địa chỉ>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, "")
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Chẩn đoán lâm sàng>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, "")
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Người chỉ định>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, "")
            Loop

            RichEditControl1.Document.EndUpdate()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedIndex = 1 Then
            'Fill camera list combobox with available cameras
            FillCameraList()

            'Select the first one
            If (comboBoxCameraList.Items.Count > 0) Then
                comboBoxCameraList.SelectedIndex = 0
            End If

            'Fill camera list combobox with available resolutions
            FillResolutionList()
            buttonSnapshotNextSourceFrame.Visible = True
        Else
            buttonSnapshotNextSourceFrame.Visible = False
            cameraControl.CloseCamera()
        End If
    End Sub
    ' Zooming
    Dim _bZoomed = False
    Dim _fZoomValue = 1.0
    Dim _CameraChoice As CameraChoice = New CameraChoice()
    Private Sub FillCameraList()
        comboBoxCameraList.Items.Clear()
        _CameraChoice.UpdateDeviceList()
        For Each camera_device In _CameraChoice.Devices
            comboBoxCameraList.Items.Add(camera_device.Name)
        Next
    End Sub
    Private Sub FillResolutionList()
        comboBoxResolutionList.Items.Clear()
        If Not cameraControl.CameraCreated Then Return
        Dim resolutions As ResolutionList = Camera.GetResolutionList(cameraControl.Moniker)
        If resolutions Is Nothing Then Return
        Dim index_to_select As Integer = -1

        For index As Integer = 0 To resolutions.Count - 1
            comboBoxResolutionList.Items.Add(resolutions(index).ToString())
            If Ten_Nhom = "SIEUAM" Then
                If resolutions(index).Width = 1280 And resolutions(index).Height = 1024 Then
                    index_to_select = index
                End If
            Else
                If resolutions(index).CompareTo(cameraControl.Resolution) = 0 Then
                    index_to_select = index
                End If
            End If

        Next

        If index_to_select >= 0 Then
            comboBoxResolutionList.SelectedIndex = index_to_select
        End If
    End Sub

    Private Sub grv_DichVu_DoubleClick(sender As Object, e As EventArgs) Handles grv_DichVu.DoubleClick
        DockPanel2.Enabled = True
        DockPanel3.Enabled = True
        grd_ChiDinh.Enabled = False
    End Sub

    Private Sub btn_LuuKetQua_Click(sender As Object, e As EventArgs) Handles btn_LuuKetQua.Click
        DockPanel2.Enabled = False
        DockPanel3.Enabled = False
        grd_ChiDinh.Enabled = True
    End Sub

    Private Sub grdDS_mauKQ_DoubleClick(sender As Object, e As EventArgs) Handles grdDS_mauKQ.DoubleClick
        If grdDS_mauKQ.Item(grdDS_mauKQ.Row, 0) = Nothing Then Exit Sub
        Fill_Mau(TenDangNhap, grdDS_mauKQ.Item(grdDS_mauKQ.Row, 0), grdDS_mauKQ.Item(grdDS_mauKQ.Row, 1), grdDS_mauKQ.Item(grdDS_mauKQ.Row, 2))
        panDS_mauKQ.Visible = False
        Fill_DataHC2Word()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        RichEditControl1.Document.BeginUpdate()
        Dim sMaCLS As String = grv_DichVu.GetFocusedRowCellValue("MaDichVu").ToString()
        'Dim sMaPhieuCD As String = grv_DichVu.GetFocusedRowCellValue("MaPhieuCD").ToString()
        'sMaCLS = grdYC_CLS.GetData(grdYC_CLS.RowSel, 0)
        Dim ivt As ListViewItem = New ListViewItem()
        ivt.ImageIndex = ImageList1.Images.Count - 1
        ListView1.Items.Add(ivt)
        ListView1.Refresh()
        'Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
        sTenBenhNhan = TenABC(sTenBenhNhan)
        Dim strPath = "D:\KetQua_CDHA\" + sMaKhamBenh + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + (ListView1.FocusedItem.ImageIndex + 1).ToString() + ".jpg" 'Path + "\" + txtSophieuCD.Text + "_" + grv_YeuCau.GetFocusedRowCellValue("MaCDHA").ToString() + "_" + ImageList1.Images.Count.ToString() + ".jpg"
        ''strPath = "C:\Users\Admin\Desktop\New folder (2)\Phạm Thị Minh Phương_CD1808150006__7.jpg"
        'Dim i = 0

        'Dim im_iTeam As Image = ImageList1.Images(ListView1.FocusedItem.ImageIndex)
        Dim newImage = New Bitmap(150, 150)
        Dim im_iTeam As Image = Image.FromFile(strPath)

        Using gr = Graphics.FromImage(newImage)
            gr.SmoothingMode = SmoothingMode.HighQuality
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality
            gr.DrawImage(im_iTeam, New Rectangle(0, 0, 150, 150))
        End Using

        ''chen anh
        Dim myPic As DocumentImage = RichEditControl1.Document.InsertImage(RichEditControl1.Document.CaretPosition, DevExpress.XtraRichEdit.API.Native.DocumentImageSource.FromFile(strPath))
        myPic.ScaleX = 2.5 / 10
        myPic.ScaleY = 2.5 / 10

        RichEditControl1.Document.EndUpdate()
    End Sub
End Class
