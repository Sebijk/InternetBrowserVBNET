<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMedia
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public dlgCommonDialogOpen As System.Windows.Forms.OpenFileDialog
    Public WithEvents timTimer As System.Windows.Forms.Timer
    Public WithEvents MediaPlayer As AxMediaPlayer.AxMediaPlayer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedia))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dlgCommonDialogOpen = New System.Windows.Forms.OpenFileDialog()
        Me.timTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MediaPlayer = New AxMediaPlayer.AxMediaPlayer()
        Me.cboAddress = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.btnEigenschaften = New System.Windows.Forms.ToolStripButton()
        CType(Me.MediaPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'timTimer
        '
        Me.timTimer.Interval = 5
        '
        'MediaPlayer
        '
        Me.MediaPlayer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MediaPlayer.Location = New System.Drawing.Point(3, 59)
        Me.MediaPlayer.Name = "MediaPlayer"
        Me.MediaPlayer.Size = New System.Drawing.Size(357, 323)
        Me.MediaPlayer.TabIndex = 3
        '
        'cboAddress
        '
        Me.cboAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAddress.BackColor = System.Drawing.SystemColors.Window
        Me.cboAddress.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAddress.Location = New System.Drawing.Point(3, 32)
        Me.cboAddress.Name = "cboAddress"
        Me.cboAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboAddress.Size = New System.Drawing.Size(357, 21)
        Me.cboAddress.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.btnEigenschaften})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(365, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpen
        '
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(76, 22)
        Me.btnOpen.Text = "Datei öffnen"
        '
        'btnEigenschaften
        '
        Me.btnEigenschaften.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnEigenschaften.Image = CType(resources.GetObject("btnEigenschaften.Image"), System.Drawing.Image)
        Me.btnEigenschaften.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEigenschaften.Name = "btnEigenschaften"
        Me.btnEigenschaften.Size = New System.Drawing.Size(85, 22)
        Me.btnEigenschaften.Text = "Eigenschaften"
        '
        'frmMedia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(365, 384)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cboAddress)
        Me.Controls.Add(Me.MediaPlayer)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(11, 50)
        Me.Name = "frmMedia"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Media Player"
        CType(Me.MediaPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents cboAddress As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEigenschaften As System.Windows.Forms.ToolStripButton
#End Region
End Class