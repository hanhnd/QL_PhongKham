<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCLS_ThongKeBenhNhanXN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCLS_ThongKeBenhNhanXN))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtThang = New C1.Win.C1Input.C1DateEdit
        Me.lblNgay = New System.Windows.Forms.Label
        Me.cmdXuatExcel = New System.Windows.Forms.Button
        Me.pbThongke = New System.Windows.Forms.ProgressBar
        Me.cmdInBC = New System.Windows.Forms.Button
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.cmdThuchien = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.grdDS = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Panel1.SuspendLayout()
        CType(Me.txtThang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtThang)
        Me.Panel1.Controls.Add(Me.lblNgay)
        Me.Panel1.Controls.Add(Me.cmdXuatExcel)
        Me.Panel1.Controls.Add(Me.pbThongke)
        Me.Panel1.Controls.Add(Me.cmdInBC)
        Me.Panel1.Controls.Add(Me.cmdThoat)
        Me.Panel1.Controls.Add(Me.cmdThuchien)
        Me.Panel1.Location = New System.Drawing.Point(3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(953, 49)
        Me.Panel1.TabIndex = 213
        '
        'txtThang
        '
        Me.txtThang.BackColor = System.Drawing.SystemColors.Window
        Me.txtThang.CustomFormat = "MM/yyyy"
        Me.txtThang.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThang.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtThang.Location = New System.Drawing.Point(73, 13)
        Me.txtThang.Name = "txtThang"
        Me.txtThang.Size = New System.Drawing.Size(163, 24)
        Me.txtThang.TabIndex = 256
        Me.txtThang.Tag = Nothing
        '
        'lblNgay
        '
        Me.lblNgay.AutoSize = True
        Me.lblNgay.BackColor = System.Drawing.Color.Transparent
        Me.lblNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgay.Location = New System.Drawing.Point(17, 18)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(50, 16)
        Me.lblNgay.TabIndex = 255
        Me.lblNgay.Text = "Tháng:"
        '
        'cmdXuatExcel
        '
        Me.cmdXuatExcel.BackColor = System.Drawing.Color.Transparent
        Me.cmdXuatExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXuatExcel.Location = New System.Drawing.Point(783, 9)
        Me.cmdXuatExcel.Name = "cmdXuatExcel"
        Me.cmdXuatExcel.Size = New System.Drawing.Size(77, 30)
        Me.cmdXuatExcel.TabIndex = 253
        Me.cmdXuatExcel.Text = "Xuất Excel"
        Me.cmdXuatExcel.UseVisualStyleBackColor = False
        '
        'pbThongke
        '
        Me.pbThongke.Location = New System.Drawing.Point(317, 14)
        Me.pbThongke.Name = "pbThongke"
        Me.pbThongke.Size = New System.Drawing.Size(282, 22)
        Me.pbThongke.TabIndex = 251
        '
        'cmdInBC
        '
        Me.cmdInBC.BackColor = System.Drawing.Color.Transparent
        Me.cmdInBC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInBC.Location = New System.Drawing.Point(700, 9)
        Me.cmdInBC.Name = "cmdInBC"
        Me.cmdInBC.Size = New System.Drawing.Size(77, 30)
        Me.cmdInBC.TabIndex = 248
        Me.cmdInBC.Text = "In báo cáo"
        Me.cmdInBC.UseVisualStyleBackColor = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.Color.Transparent
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThoat.Location = New System.Drawing.Point(866, 9)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(76, 30)
        Me.cmdThoat.TabIndex = 247
        Me.cmdThoat.Text = "Thoát"
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'cmdThuchien
        '
        Me.cmdThuchien.BackColor = System.Drawing.Color.Transparent
        Me.cmdThuchien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThuchien.Location = New System.Drawing.Point(614, 9)
        Me.cmdThuchien.Name = "cmdThuchien"
        Me.cmdThuchien.Size = New System.Drawing.Size(76, 30)
        Me.cmdThuchien.TabIndex = 241
        Me.cmdThuchien.Text = "Thực hiện"
        Me.cmdThuchien.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(3, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(953, 24)
        Me.Label12.TabIndex = 175
        Me.Label12.Text = "Báo cáo khoa xét nghiệm - GPBL"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdDS
        '
        Me.grdDS.AllowEditing = False
        Me.grdDS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdDS.BackgroundImage = CType(resources.GetObject("grdDS.BackgroundImage"), System.Drawing.Image)
        Me.grdDS.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdDS.ColumnInfo = "0,0,0,0,0,115,Columns:"
        Me.grdDS.Location = New System.Drawing.Point(3, 84)
        Me.grdDS.Name = "grdDS"
        Me.grdDS.Rows.Count = 0
        Me.grdDS.Rows.Fixed = 0
        Me.grdDS.Rows.MinSize = 20
        Me.grdDS.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdDS.Size = New System.Drawing.Size(953, 555)
        Me.grdDS.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdDS.Styles"))
        Me.grdDS.TabIndex = 217
        '
        'frmCLS_ThongKeBenhNhanXN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(959, 644)
        Me.Controls.Add(Me.grdDS)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label12)
        Me.KeyPreview = True
        Me.Name = "frmCLS_ThongKeBenhNhanXN"
        Me.Text = "Báo cáo khoa xét nghiệm - GPBL [Báo cáo tháng]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtThang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmdThuchien As System.Windows.Forms.Button
    Friend WithEvents cmdInBC As System.Windows.Forms.Button
    Friend WithEvents grdDS As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pbThongke As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdXuatExcel As System.Windows.Forms.Button
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents txtThang As C1.Win.C1Input.C1DateEdit

End Class
