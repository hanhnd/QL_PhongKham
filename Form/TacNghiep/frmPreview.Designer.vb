<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreview
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
        Me.arViewer = New DataDynamics.ActiveReports.Viewer.Viewer
        Me.SuspendLayout()
        '
        'arViewer
        '
        Me.arViewer.BackColor = System.Drawing.SystemColors.Control
        Me.arViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.arViewer.Document = New DataDynamics.ActiveReports.Document.Document("ARNet Document")
        Me.arViewer.Location = New System.Drawing.Point(0, 0)
        Me.arViewer.Name = "arViewer"
        Me.arViewer.ReportViewer.AllowSplitter = False
        Me.arViewer.ReportViewer.BackColor = System.Drawing.SystemColors.Control
        Me.arViewer.ReportViewer.CurrentPage = 0
        Me.arViewer.ReportViewer.MultiplePageCols = 3
        Me.arViewer.ReportViewer.MultiplePageRows = 2
        Me.arViewer.ReportViewer.RulerVisible = False
        Me.arViewer.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal
        Me.arViewer.Size = New System.Drawing.Size(976, 593)
        Me.arViewer.TabIndex = 1
        Me.arViewer.TableOfContents.Text = "Contents"
        Me.arViewer.TableOfContents.Width = 200
        Me.arViewer.TabTitleLength = 35
        Me.arViewer.Toolbar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'frmPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 593)
        Me.Controls.Add(Me.arViewer)
        Me.Name = "frmPreview"
        Me.Text = "frmPreview"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents arViewer As DataDynamics.ActiveReports.Viewer.Viewer
End Class
