<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCLS_DichVuDaThuPhi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCLS_DichVuDaThuPhi))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdXuatExcel = New System.Windows.Forms.Button
        Me.txtDen = New C1.Win.C1Input.C1DateEdit
        Me.cmdInBC = New System.Windows.Forms.Button
        Me.txtTu = New C1.Win.C1Input.C1DateEdit
        Me.lblNgay = New System.Windows.Forms.Label
        Me.cmdThuchien = New System.Windows.Forms.Button
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdDS = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Label12 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtDen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdThoat)
        Me.GroupBox1.Controls.Add(Me.cmdXuatExcel)
        Me.GroupBox1.Controls.Add(Me.cmdThuchien)
        Me.GroupBox1.Controls.Add(Me.txtDen)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblNgay)
        Me.GroupBox1.Controls.Add(Me.cmdInBC)
        Me.GroupBox1.Controls.Add(Me.txtTu)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1021, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmdXuatExcel
        '
        Me.cmdXuatExcel.BackColor = System.Drawing.Color.Transparent
        Me.cmdXuatExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXuatExcel.Location = New System.Drawing.Point(680, 12)
        Me.cmdXuatExcel.Name = "cmdXuatExcel"
        Me.cmdXuatExcel.Size = New System.Drawing.Size(91, 31)
        Me.cmdXuatExcel.TabIndex = 261
        Me.cmdXuatExcel.Text = "Xuất Excel"
        Me.cmdXuatExcel.UseVisualStyleBackColor = False
        '
        'txtDen
        '
        Me.txtDen.BackColor = System.Drawing.Color.White
        Me.txtDen.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtDen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDen.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtDen.Location = New System.Drawing.Point(298, 17)
        Me.txtDen.Name = "txtDen"
        Me.txtDen.Size = New System.Drawing.Size(162, 22)
        Me.txtDen.TabIndex = 259
        Me.txtDen.Tag = Nothing
        '
        'cmdInBC
        '
        Me.cmdInBC.BackColor = System.Drawing.Color.Transparent
        Me.cmdInBC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInBC.Location = New System.Drawing.Point(562, 13)
        Me.cmdInBC.Name = "cmdInBC"
        Me.cmdInBC.Size = New System.Drawing.Size(112, 31)
        Me.cmdInBC.TabIndex = 258
        Me.cmdInBC.Text = "In danh sách"
        Me.cmdInBC.UseVisualStyleBackColor = False
        '
        'txtTu
        '
        Me.txtTu.BackColor = System.Drawing.Color.White
        Me.txtTu.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtTu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTu.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtTu.Location = New System.Drawing.Point(95, 17)
        Me.txtTu.Name = "txtTu"
        Me.txtTu.Size = New System.Drawing.Size(162, 22)
        Me.txtTu.TabIndex = 256
        Me.txtTu.Tag = Nothing
        '
        'lblNgay
        '
        Me.lblNgay.AutoSize = True
        Me.lblNgay.BackColor = System.Drawing.Color.Transparent
        Me.lblNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgay.Location = New System.Drawing.Point(10, 20)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(80, 16)
        Me.lblNgay.TabIndex = 255
        Me.lblNgay.Text = "Thời gian từ:"
        '
        'cmdThuchien
        '
        Me.cmdThuchien.BackColor = System.Drawing.Color.Transparent
        Me.cmdThuchien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThuchien.Location = New System.Drawing.Point(464, 13)
        Me.cmdThuchien.Name = "cmdThuchien"
        Me.cmdThuchien.Size = New System.Drawing.Size(92, 31)
        Me.cmdThuchien.TabIndex = 257
        Me.cmdThuchien.Text = "Thực hiện"
        Me.cmdThuchien.UseVisualStyleBackColor = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.Color.Transparent
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThoat.Location = New System.Drawing.Point(777, 12)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(84, 31)
        Me.cmdThoat.TabIndex = 262
        Me.cmdThoat.Text = "Thoát"
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(261, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 16)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Đến:"
        '
        'grdDS
        '
        Me.grdDS.AllowEditing = False
        Me.grdDS.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.grdDS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDS.BackgroundImage = CType(resources.GetObject("grdDS.BackgroundImage"), System.Drawing.Image)
        Me.grdDS.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdDS.ColumnInfo = resources.GetString("grdDS.ColumnInfo")
        Me.grdDS.ExtendLastCol = True
        Me.grdDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDS.Location = New System.Drawing.Point(5, 78)
        Me.grdDS.Name = "grdDS"
        Me.grdDS.Rows.Count = 1
        Me.grdDS.Rows.MinSize = 20
        Me.grdDS.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdDS.Size = New System.Drawing.Size(1016, 398)
        Me.grdDS.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdDS.Styles"))
        Me.grdDS.TabIndex = 219
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(5, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(1016, 24)
        Me.Label12.TabIndex = 218
        Me.Label12.Text = "Thống kê số lượng && tổng tiên đã thu theo dịch vụ"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCLS_DichVuDaThuPhi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 482)
        Me.Controls.Add(Me.grdDS)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCLS_DichVuDaThuPhi"
        Me.Text = "Thống kê lượt dịch vụ đã thu phí"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtDen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdXuatExcel As System.Windows.Forms.Button
    Friend WithEvents cmdThuchien As System.Windows.Forms.Button
    Friend WithEvents txtDen As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblNgay As System.Windows.Forms.Label
    Friend WithEvents cmdInBC As System.Windows.Forms.Button
    Friend WithEvents txtTu As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdDS As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
