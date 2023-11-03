<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDS_SoTayChiDinh
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDS_SoTayChiDinh))
        Me.grdChitietND_PPDT = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.grdChitietND_PPDT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdChitietND_PPDT
        '
        Me.grdChitietND_PPDT.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdChitietND_PPDT.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.grdChitietND_PPDT.ColumnInfo = resources.GetString("grdChitietND_PPDT.ColumnInfo")
        Me.grdChitietND_PPDT.ExtendLastCol = True
        Me.grdChitietND_PPDT.Location = New System.Drawing.Point(12, 12)
        Me.grdChitietND_PPDT.Name = "grdChitietND_PPDT"
        Me.grdChitietND_PPDT.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdChitietND_PPDT.Size = New System.Drawing.Size(393, 448)
        Me.grdChitietND_PPDT.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdChitietND_PPDT.Styles"))
        Me.grdChitietND_PPDT.TabIndex = 90
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.PhongKham.My.Resources.Resources.deletered
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(224, 465)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 28)
        Me.btnDelete.TabIndex = 91
        Me.btnDelete.Text = "Xóa"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Image = Global.PhongKham.My.Resources.Resources._exit
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(312, 465)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 28)
        Me.btnClose.TabIndex = 91
        Me.btnClose.Text = "Đóng"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmDS_SoTayChiDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 499)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.grdChitietND_PPDT)
        Me.Name = "frmDS_SoTayChiDinh"
        CType(Me.grdChitietND_PPDT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdChitietND_PPDT As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
