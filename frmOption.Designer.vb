<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOption
#Region "Vom Windows Form-Designer generierter Code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
		InitializeComponent()
		'Dieses Formular ist MDI-untergeordnet.
		'Dieser Code simuliert die VB6-
		'Funktionalität des automatischen
		' Ladens und Anzeigens eines dem MDI-untergeordneten Formular
		' übergeordneten Elements.
	End Sub
	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents CookieForm As System.Windows.Forms.Button
    Public WithEvents InetSettings As System.Windows.Forms.Button
    Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents TextLabel As System.Windows.Forms.Label
    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Verändern mit dem Windows Form-Designer ist nicht möglich.
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CookieForm = New System.Windows.Forms.Button()
        Me.InetSettings = New System.Windows.Forms.Button()
        Me.Picture1 = New System.Windows.Forms.PictureBox()
        Me.TextLabel = New System.Windows.Forms.Label()
        Me.geckoconfigButton = New System.Windows.Forms.Button()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CookieForm
        '
        Me.CookieForm.BackColor = System.Drawing.SystemColors.Control
        Me.CookieForm.Cursor = System.Windows.Forms.Cursors.Default
        Me.CookieForm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CookieForm.Location = New System.Drawing.Point(54, 149)
        Me.CookieForm.Name = "CookieForm"
        Me.CookieForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CookieForm.Size = New System.Drawing.Size(137, 33)
        Me.CookieForm.TabIndex = 3
        Me.CookieForm.Text = "Cookies verwalten"
        Me.CookieForm.UseVisualStyleBackColor = False
        '
        'InetSettings
        '
        Me.InetSettings.BackColor = System.Drawing.SystemColors.Control
        Me.InetSettings.Cursor = System.Windows.Forms.Cursors.Default
        Me.InetSettings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.InetSettings.Location = New System.Drawing.Point(54, 71)
        Me.InetSettings.Name = "InetSettings"
        Me.InetSettings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.InetSettings.Size = New System.Drawing.Size(137, 33)
        Me.InetSettings.TabIndex = 2
        Me.InetSettings.Text = "Internetoptionen (Trident)"
        Me.InetSettings.UseVisualStyleBackColor = False
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Image = Global.sjbrowser.My.Resources.Resources.internet_web_browser
        Me.Picture1.InitialImage = Global.sjbrowser.My.Resources.Resources.internet_web_browser
        Me.Picture1.Location = New System.Drawing.Point(9, 9)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(46, 53)
        Me.Picture1.TabIndex = 0
        Me.Picture1.TabStop = False
        '
        'TextLabel
        '
        Me.TextLabel.BackColor = System.Drawing.SystemColors.Control
        Me.TextLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextLabel.Location = New System.Drawing.Point(61, 9)
        Me.TextLabel.Name = "TextLabel"
        Me.TextLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextLabel.Size = New System.Drawing.Size(147, 53)
        Me.TextLabel.TabIndex = 1
        Me.TextLabel.Text = "Wählen Sie eine Option aus, um Sebijk's Internet-Browser zu konfigurieren:"
        '
        'geckoconfigButton
        '
        Me.geckoconfigButton.BackColor = System.Drawing.SystemColors.Control
        Me.geckoconfigButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.geckoconfigButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.geckoconfigButton.Location = New System.Drawing.Point(54, 110)
        Me.geckoconfigButton.Name = "geckoconfigButton"
        Me.geckoconfigButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.geckoconfigButton.Size = New System.Drawing.Size(137, 33)
        Me.geckoconfigButton.TabIndex = 7
        Me.geckoconfigButton.Text = "about:config (Gecko)"
        Me.geckoconfigButton.UseVisualStyleBackColor = False
        '
        'frmOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(228, 195)
        Me.Controls.Add(Me.geckoconfigButton)
        Me.Controls.Add(Me.CookieForm)
        Me.Controls.Add(Me.InetSettings)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.TextLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(184, 249)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOption"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Optionen"
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents geckoconfigButton As System.Windows.Forms.Button
#End Region 
End Class