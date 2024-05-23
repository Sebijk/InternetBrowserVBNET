<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.exBrowser = New sjbrowser.exBrowser
        Me.SuspendLayout()
        '
        'exBrowser
        '
        Me.exBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.exBrowser.Location = New System.Drawing.Point(0, 0)
        Me.exBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.exBrowser.Name = "exBrowser"
        Me.exBrowser.Size = New System.Drawing.Size(615, 397)
        Me.exBrowser.TabIndex = 0
        Me.exBrowser.Url = New System.Uri("about:blank", System.UriKind.Absolute)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 397)
        Me.Controls.Add(Me.exBrowser)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Browser"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents exBrowser As sjbrowser.exBrowser

End Class
